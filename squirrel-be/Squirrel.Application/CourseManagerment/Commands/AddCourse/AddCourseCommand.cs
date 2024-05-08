using Squirrel.Application.Common.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squirrel.Application.CategoryManagerment.Commands.AddCourse
{
    public class AddCourseCommand : BaseRequest<AddCourseResponse>
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? ImgUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
