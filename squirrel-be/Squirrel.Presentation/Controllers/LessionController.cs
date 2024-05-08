using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Squirrel.Application.CategoryManagerment.Commands.AddLesson;
using Squirrel.Application.CategoryManagerment.Queries.GetLessons;

namespace Squirrel.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LessionController : SquirrelController
    {
        [HttpPost]
        [Route("AddLesson")]
        public async Task<IActionResult> AddCategory([FromBody] AddLessonCommand request)
        {
            var response = await Mediator.Send(request);
            return Response(response);
        }

        [HttpGet]
        [Route("GetLessons")]
        public async Task<IActionResult> GetCategories([FromQuery] GetLessonsRequest request)
        {
            return Response(await Mediator.Send(request));
        }
    }
}
