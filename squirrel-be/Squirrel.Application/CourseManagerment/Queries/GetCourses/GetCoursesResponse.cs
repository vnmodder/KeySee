using Squirrel.Application.UserManagement.Queries.GetUserInformationList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squirrel.Application.CategoryManagerment.Queries.GetCourses
{
    public class GetCoursesResponse
    {
        public bool IsSuccess { get; set; } = true;
        public string ErrorCode { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;

        public List<CourseModel> Courses { get; set; } = new List<CourseModel>();

    }

    public class CourseModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? ImgUrl { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int CompletedLessons { get; set; }
        public int TotalLessons { get; set; }
    }
}
