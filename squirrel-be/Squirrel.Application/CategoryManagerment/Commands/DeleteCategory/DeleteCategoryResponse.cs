using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squirrel.Application.CategoryManagerment.Commands.DeleteCategory
{
    public class DeleteCategoryResponse
    {
        public bool IsSuccess { get => String.IsNullOrEmpty(Message); }
        public string? ErrorCode { get; set; }
        public string? Message { get; set; }
    }
}
