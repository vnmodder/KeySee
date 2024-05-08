using Squirrel.Application.Common.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squirrel.Application.CategoryManagerment.Queries.GetCourses
{
    public class GetCoursesRequest : BaseRequest<GetCoursesResponse>
    {
        public int? Id { get; set; }
    }
}
