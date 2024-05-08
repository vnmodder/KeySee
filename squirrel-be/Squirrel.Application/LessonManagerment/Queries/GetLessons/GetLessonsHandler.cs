using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Squirrel.Application.Common.CQRS;
using Squirrel.Application.Common.Interfaces;
using Squirrel.Domain.Exceptions;
using Squirrel.Domain.Messages;
using Squirrel.Infrastructure.Databases.SquirrelDB;
using Squirrel.Infrastructure.Databases.SquirrelDB.Entities;

namespace Squirrel.Application.CategoryManagerment.Queries.GetLessons
{
    public class GetLessonsHandler : BaseQueryHandler<GetLessonsRequest, GetLessonsResponse>
    {
        public GetLessonsHandler(
            SquirrelDbContext dbContext,
            IMapper mapper,
            ILogService log) : base(dbContext, mapper, log)
        {

        }
        public override async Task<GetLessonsResponse> Handle(GetLessonsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.CourseId.HasValue)
                {
                    return new GetLessonsResponse()
                    {
                        Lessons = _mapper.Map<List<LessonModel>>(await GetLessonsByCourseId(request.CourseId ?? 0))
                    };
                }

                var lessions = await _dbContext.Lessons.Where(x=>
                                        request.Id== null|| x.Id == request.Id)
                                        .ToListAsync();
                return new GetLessonsResponse()
                {
                    Lessons = _mapper.Map<List<LessonModel>>(lessions)
                };
            }
            catch (Exception ex)
            {
                _log.Error("Couldn't get data from database", ex, request);
                throw ExceptionHelper.GenerateBusinessException(nameof(ErrorMessages.EM0035), ex);
            }
        }

        private async Task<List<Lesson>> GetLessonsByCourseId(int courseId)
        {
            return await _dbContext.Lessons.Where(x=>x.CourseId == courseId).ToListAsync();
        }
    }
}
