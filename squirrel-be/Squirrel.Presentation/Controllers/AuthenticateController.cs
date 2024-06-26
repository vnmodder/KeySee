﻿using Squirrel.Application.Authenticate.Login;
using Squirrel.Application.Authenticate.Signup;
using Squirrel.Domain.Exceptions;
using Squirrel.Domain.Messages;
using Squirrel.Infrastructure.Constants;
using Squirrel.Infrastructure.Databases.SquirrelDB.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Squirrel.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : SquirrelController
    {
        private readonly SignInManager<User> _signInManager;

        public AuthenticateController(SignInManager<User> signInManager) : base()
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await Mediator.Send(request);
            if (!response.LoginSuccessFlag)
            {
                throw new BusinessException(errorCode: nameof(ValidationMessages.VM0065), message: ValidationMessages.VM0065);
            }

            return Response(response);
        }

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync().ConfigureAwait(false);
            HttpContext.Response.Cookies.Delete(".AspNetCore.Cookies");
            return Ok();
        }


        [HttpPost]
        [Route("Signup")]
        public async Task<IActionResult> Signup([FromBody] SignupRequest request)
        {
            var response = await Mediator.Send(request);
            if (!response.IsSuccess)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
