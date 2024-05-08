using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Squirrel.Application.CategoryManagerment.Commands.AddCourse;
using Squirrel.Application.CategoryManagerment.Queries.GetCourses;

namespace Squirrel.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourcseController : SquirrelController
    {
        [HttpPost]
        [Route("AddCourse")]
        [Authorize]
        public async Task<IActionResult> AddCategory([FromBody] AddCourseCommand request)
        {
            var response = await Mediator.Send(request);
            return Response(response);
        }

        [HttpGet]
        [Route("GetCourses")]
        public async Task<IActionResult> GetCategories([FromQuery] GetCoursesRequest request)
        {
            return Response(await Mediator.Send(request));
        }
    }
}
