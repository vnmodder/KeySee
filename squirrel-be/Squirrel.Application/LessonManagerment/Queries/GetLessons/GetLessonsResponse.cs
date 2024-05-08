using Squirrel.Application.UserManagement.Queries.GetUserInformationList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squirrel.Application.CategoryManagerment.Queries.GetLessons
{
    public class GetLessonsResponse
    {
        public bool IsSuccess { get; set; } = true;
        public string ErrorCode { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;

        public List<LessonModel> Lessons { get; set; } = new List<LessonModel>();

    }

    public class LessonModel
    {
        public string? Title { get; set; }
        public string? VideoUrl { get; set; }
        public string? Content { get; set; }
        public string? ImgUrl { get; set; }
        public bool IsCompleted { get; set; }
        public int CourseId { get; set; }
    }
}
