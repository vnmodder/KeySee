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

namespace Squirrel.Application.CategoryManagerment.Commands.AddCategory
{
    public class AddCategoryHandler : BaseCommandHandler<AddCategoryCommand, AddCategoryResponse>
    {

        public AddCategoryHandler(
            SquirrelDbContext dbContext,
            IMapper mapper,
            IUserService userService,
            ILogService log) : base(dbContext, mapper, userService, log)
        {

        }
        public override async Task<AddCategoryResponse> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                return new AddCategoryResponse() { Message = "Name không được để trống" };
            }

            var category = new Category()
            {
                Name = request.Name,
                Description = request.Description,
                ImgUrl = request.ImgUrl,
                InsertUserId = _userService.UserId,
                InsertDate = _now
            };

            using (var trans = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.Categories.Add(category);
                    _dbContext.SaveChanges();
                    await trans.CommitAsync(cancellationToken);

                    return new AddCategoryResponse();
                }
                catch (Exception ex)
                {
                    await trans.RollbackAsync();
                    _log.Error("Add category FAILED", ex, request);
                    throw ExceptionHelper.GenerateBusinessException(nameof(ErrorMessages.EM0035));
                }
            }

        }
    }
}
