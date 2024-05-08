using Squirrel.Application.Common.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squirrel.Application.CategoryManagerment.Queries.GetCategories
{
    public class GetCategoriesRequest : BaseRequest<GetCategoriesResponse>
    {
        public int? Id { get; set; }
    }
}
