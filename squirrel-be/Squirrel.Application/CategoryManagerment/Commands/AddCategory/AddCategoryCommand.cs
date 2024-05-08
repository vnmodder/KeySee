using Squirrel.Application.Common.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squirrel.Application.CategoryManagerment.Commands.AddCategory
{
    public class AddCategoryCommand : BaseRequest<AddCategoryResponse>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImgUrl { get; set; }
    }
}
