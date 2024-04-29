using Squirrel.Application.UserManagement.Queries.GetUserInformationList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Squirrel.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : SquirrelController
    {
        /// <summary>
        /// Get list all users
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("user-information-list")]
        public async Task<IActionResult> GetUserInformationList([FromQuery] GetUserInformationListRequest request)
        {
            var response = await Mediator.Send(request);
            return Response(response);
        }
    }
}
