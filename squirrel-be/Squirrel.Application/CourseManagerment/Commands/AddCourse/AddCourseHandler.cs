using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Squirrel.Application.Common.CQRS;
using Squirrel.Application.Common.Interfaces;
using Squirrel.Infrastructure.Databases.SquirrelDB;
using SquirrelUser = Squirrel.Infrastructure.Databases.SquirrelDB.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Squirrel.Application.Common.Services;
using Squirrel.Infrastructure.Databases.SquirrelDB.Entities;
using Squirrel.Domain.Exceptions;
using Squirrel.Domain.Messages;
using Microsoft.EntityFrameworkCore;
using Squirrel.Application.CategoryManagerment.Commands.AddCategory;

namespace Squirrel.Application.CategoryManagerment.Commands.AddCourse
{
    public class AddCourseHandler : BaseCommandHandler<AddCourseCommand, AddCourseResponse>
    {

        public AddCourseHandler(
            SquirrelDbContext dbContext,
            IMapper mapper,
            IUserService userService,
            ILogService log) : base(dbContext, mapper, userService, log)
        {

        }
        public override async Task<AddCourseResponse> Handle(AddCourseCommand request, CancellationToken cancellationToken)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == request.CategoryId);

            if (category == null)
            {
                return new AddCourseResponse() { Message = $"không tìm thấy CategoryId: {request.CategoryId}" };
            }

            var course = new Course()
            {
                Title = request.Title,
                Description = request.Description,
                Price = request.Price,
                ImgUrl = request.ImgUrl,
                CategoryId = request.CategoryId,
            };

            using (var trans = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.Courses.Add(course);
                    _dbContext.SaveChanges();
                    await trans.CommitAsync(cancellationToken);

                    return new AddCourseResponse();
                }
                catch (Exception ex)
                {
                    await trans.RollbackAsync();
                    _log.Error("Add Course FAILED", ex, request);
                    throw ExceptionHelper.GenerateBusinessException(nameof(ErrorMessages.EM0035));
                }
            }

        }
    }
}
