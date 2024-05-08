using Squirrel.Application.Common.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squirrel.Application.CategoryManagerment.Queries.GetLessons
{
    public class GetLessonsRequest : BaseRequest<GetLessonsResponse>
    {
        public int? Id { get; set; }
        public int? CourseId { get; set; }
    }
}
