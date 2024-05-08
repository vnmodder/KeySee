using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Squirrel.Application.Authenticate.Login;
using Squirrel.Application.CategoryManagerment.Commands.AddCategory;
using Squirrel.Application.CategoryManagerment.Queries.GetCategories;
using Squirrel.Domain.Exceptions;
using Squirrel.Domain.Messages;

namespace Squirrel.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class CategoryController : SquirrelController
    {
        [HttpPost]
        [Route("AddCategory")]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryCommand request)
        {
            var response = await Mediator.Send(request);
            return Response(response);
        }

        [HttpGet]
        [Route("GetCategories")]
        public async Task<IActionResult> GetCategories([FromQuery] GetCategoriesRequest request)
        {
            return Response(await Mediator.Send(request));
        }
    }
}
