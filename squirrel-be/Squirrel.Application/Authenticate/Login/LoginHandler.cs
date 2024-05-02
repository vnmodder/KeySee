
using AutoMapper;
using Squirrel.Application.Common.CQRS;
using Squirrel.Application.Common.Interfaces;
using Squirrel.Infrastructure.Databases;
using Squirrel.Infrastructure.Databases.SquirrelDB;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SquirrelUser = Squirrel.Infrastructure.Databases.SquirrelDB.Entities.User;
using Squirrel.Application.Authenticate.Login.Model;
using Microsoft.EntityFrameworkCore;

namespace Squirrel.Application.Authenticate.Login
{
    public class LoginHandler : BaseCommandHandler<LoginRequest, LoginResponse>
    {
        private readonly UserManager<SquirrelUser> _userManager;
        private readonly SignInManager<SquirrelUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IDbContextFactory _dbContextFactory;

        public LoginHandler(
            SquirrelDbContext dbContext,
            IMapper mapper,
            IUserService userService,
            UserManager<SquirrelUser> userManager,
            SignInManager<SquirrelUser> signInManager,
            IConfiguration configuration,
            IDbContextFactory dbContextFactory,
            ILogService log) : base(dbContext, mapper, userService, log)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _dbContextFactory = dbContextFactory;
        }

        public override async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.LoginId) || string.IsNullOrEmpty(request.Password))
            {
                return new LoginResponse() { LoginSuccessFlag = false };
            }

            try
            {
                // Get user data.
                var user = await _userManager.FindByNameAsync(request.LoginId);
                if (user == null)
                {
                    return new LoginResponse() { LoginSuccessFlag = false };
                }

                // Verify user login information
                var signInResult = await _signInManager.PasswordSignInAsync(request.LoginId, request.Password, request.RememberMe, lockoutOnFailure: false);
                if (signInResult.Succeeded)
                {
                    LoginResponse response = new();

                    List<Task> tasks = new()
                    {
                        Task.Run(async () =>
                        {
                            response = await ClaimUserAsync(user);
                        }),
                 
                    };

                    await Task.WhenAll(tasks);

                    return response;
                }
                else
                {
                    return new LoginResponse() { LoginSuccessFlag = false };
                }
            }
            catch (Exception ex)
            {
                _log.Error(message: "LOGIN FAILED", ex, request: request);
                throw ex;
            }
        }

        /// <summary>
        /// Write authentication token and claim user information into token.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private async Task<LoginResponse> ClaimUserAsync(SquirrelUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var authenticationClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserName),
                    new Claim(ClaimTypes.Role, string.Join(",", userRoles)),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            int tokenExpireTimeInMinutes;
            if (!int.TryParse(_configuration["Setting:TokenExpTime"], out tokenExpireTimeInMinutes))
            {
                tokenExpireTimeInMinutes = 540; // 9 hours
            }

            var tokenValidTo = DateTime.UtcNow.AddMinutes(tokenExpireTimeInMinutes);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                expires: DateTime.UtcNow.AddMinutes(tokenExpireTimeInMinutes),
                claims: authenticationClaims,
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256));

            await _userManager.SetAuthenticationTokenAsync(
                user,
                "Squirrel_Server",
                "Squirrel_Token",
                new JwtSecurityTokenHandler().WriteToken(token));

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            var userInfo = await _dbContext.UserInformations.FirstOrDefaultAsync(x=>x.UserId == user.Id);

            return new LoginResponse()
            {
                UserInfo = _mapper.Map<UserInfoModel>(userInfo),
                Email = user.Email,
                Token = jwtToken,
                Expiration = tokenValidTo,
                Roles = userRoles,
                LoginSuccessFlag = true,
            };
        }
    }
}
