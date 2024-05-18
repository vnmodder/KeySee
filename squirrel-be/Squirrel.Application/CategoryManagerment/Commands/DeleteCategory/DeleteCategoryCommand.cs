using Squirrel.Application.Common.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squirrel.Application.CategoryManagerment.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : BaseRequest<DeleteCategoryResponse>
    {
        public int Id { get; set; }
    }
}
