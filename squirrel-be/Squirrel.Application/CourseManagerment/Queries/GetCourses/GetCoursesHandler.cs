using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Squirrel.Application.Common.CQRS;
using Squirrel.Application.Common.Interfaces;
using Squirrel.Domain.Exceptions;
using Squirrel.Domain.Messages;
using Squirrel.Infrastructure.Databases.SquirrelDB;

namespace Squirrel.Application.CategoryManagerment.Queries.GetCourses
{
    public class GetCoursesHandler : BaseQueryHandler<GetCoursesRequest, GetCoursesResponse>
    {
        public GetCoursesHandler(
            SquirrelDbContext dbContext,
            IMapper mapper,
            ILogService log) : base(dbContext, mapper, log)
        {

        }
        public override async Task<GetCoursesResponse> Handle(GetCoursesRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _dbContext.Courses.Where(x =>
                                                request.Id == null || x.Id == request.Id)
                                                .Join(_dbContext.Categories, co => co.CategoryId
                                                        , ca => ca.Id, (co, ca) =>
                                                        new { Co = co, CategoryName = ca.Name }
                                                        )
                                                .ToListAsync(cancellationToken);
                var courses = new List<CourseModel>();
                data.ForEach(x =>
                {
                    courses.Add(new()
                    {
                        Title = x.Co.Title,
                        Description = x.Co.Description,
                        Price = x.Co.Price,
                        ImgUrl = x.Co.ImgUrl,
                        CategoryId = x.Co.CategoryId,
                        CategoryName = x.CategoryName,
                        CompletedLessons = x.Co.CompletedLessons,
                        TotalLessons = x.Co.TotalLessons,
                    });
                });

                return new GetCoursesResponse()
                {
                    Courses = courses
                };

            }
            catch (Exception ex)
            {
                _log.Error("Couldn't get data from database", ex, request);
                throw ExceptionHelper.GenerateBusinessException(nameof(ErrorMessages.EM0035), ex);
            }
        }
    }
}
