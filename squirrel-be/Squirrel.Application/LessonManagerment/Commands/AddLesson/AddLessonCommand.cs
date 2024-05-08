using Squirrel.Application.Common.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squirrel.Application.CategoryManagerment.Commands.AddLesson
{
    public class AddLessonCommand : BaseRequest<AddLessonResponse>
    {
        public string? Title { get; set; }
        public string? VideoUrl { get; set; }
        public string? Content { get; set; }
        public string? ImgUrl { get; set; }
        public int CourseId { get; set; }
    }
}
