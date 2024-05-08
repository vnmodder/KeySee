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
using Squirrel.Application.CategoryManagerment.Commands.AddCourse;

namespace Squirrel.Application.CategoryManagerment.Commands.AddLesson
{
    public class AddLessonHandler : BaseCommandHandler<AddLessonCommand, AddLessonResponse>
    {

        public AddLessonHandler(
            SquirrelDbContext dbContext,
            IMapper mapper,
            IUserService userService,
            ILogService log) : base(dbContext, mapper, userService, log)
        {

        }
        public override async Task<AddLessonResponse> Handle(AddLessonCommand request, CancellationToken cancellationToken)
        {
            var course = _dbContext.Courses.FirstOrDefaultAsync(x => x.Id == request.CourseId);

            if (course == null)
            {
                return new AddLessonResponse() { Message = $"không tìm thấy khóa học có id: {request.CourseId}" };
            }

            var lesson = new Lesson()
            {
                Title = request.Title,
                VideoUrl = request.VideoUrl,
                Content = request.Content,
                ImgUrl = request.ImgUrl,
                IsCompleted = false,
                CourseId = request.CourseId,
            };

            using (var trans = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.Lessons.Add(lesson);
                    _dbContext.SaveChanges();
                    await trans.CommitAsync(cancellationToken);

                    return new AddLessonResponse();
                }
                catch (Exception ex)
                {
                    await trans.RollbackAsync();
                    _log.Error("Add lesson FAILED", ex, request);
                    throw ExceptionHelper.GenerateBusinessException(nameof(ErrorMessages.EM0035));
                }
            }
        }
    }
}
