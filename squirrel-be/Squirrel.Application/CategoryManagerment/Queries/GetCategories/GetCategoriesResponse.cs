using Squirrel.Application.UserManagement.Queries.GetUserInformationList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squirrel.Application.CategoryManagerment.Queries.GetCategories
{
    public class GetCategoriesResponse
    {
        public bool IsSuccess { get; set; } = true;
        public string ErrorCode { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;

        public List<CategoryModel> Categories { get; set; } = new List<CategoryModel>();

    }

    public class CategoryModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImgUrl { get; set; }
    }
}
