using AutoMapper;
using Squirrel.Application.Authenticate.Login.Model;
using Squirrel.Application.CategoryManagerment.Queries.GetCategories;
using Squirrel.Application.CategoryManagerment.Queries.GetCourses;
using Squirrel.Application.CategoryManagerment.Queries.GetLessons;
using Squirrel.Infrastructure.Databases.SquirrelDB.Entities;

namespace Application.Common.MappingProfiles
{
    public class ApproveDataProfile : Profile
    {
        public ApproveDataProfile()
        {
            CreateMap<UserInformation, UserInfoModel>();
            CreateMap<Category, CategoryModel>();
            CreateMap<Course, CourseModel>();
            CreateMap<Lesson, LessonModel>();
        }
    }
}
