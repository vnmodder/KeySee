using Squirrel.Application.Authenticate.Signup;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SquirrelUser = Squirrel.Infrastructure.Databases.SquirrelDB.Entities.User;
using Squirrel.Infrastructure.Databases;
using Squirrel.Application.Common.CQRS;
using Squirrel.Application.Common.Interfaces;
using Squirrel.Infrastructure.Databases.SquirrelDB;
using Squirrel.Domain.Exceptions;
using Squirrel.Domain.Messages;
using Squirrel.Infrastructure.Constants;
using Squirrel.Infrastructure.Databases.SquirrelDB.Entities;

namespace Squirrel.Application.Authenticate.Signup
{
    public class SignupHandler : BaseCommandHandler<SignupRequest, SignupResponse>
    {
        private readonly UserManager<SquirrelUser> _userManager;
        private readonly IDbContextFactory _dbContextFactory;
        private SquirrelUser _currentUser;

        public SignupHandler(
            SquirrelDbContext dbContext,
            IMapper mapper,
            IUserService userService,
            IDbContextFactory dbContextFactory,
            UserManager<SquirrelUser> userManager,
            ILogService log) : base(dbContext, mapper, userService, log)
        {
            _userManager = userManager;
            _dbContextFactory = dbContextFactory;
            Task.Run(async() =>{
                _currentUser = await _userManager.FindByNameAsync(_currentUserName);
            });
        }

        public override async Task<SignupResponse> Handle(SignupRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if ((user != null))
            {
                if (user.DeleteDate != null)
                {
                    throw ExceptionHelper.GenerateBusinessException(nameof(ValidationMessages.VM0121));
                }

                throw ExceptionHelper.GenerateBusinessException(nameof(ValidationMessages.VM0118));
            }

            using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {

                if (!(await InitUser(request, cancellationToken)))
                {
                    throw ExceptionHelper.GenerateBusinessException(nameof(ValidationMessages.VM0118));
                }

                if (!(await InitDateToUser(request.UserName, cancellationToken)))
                {
                    throw ExceptionHelper.GenerateBusinessException(nameof(ErrorMessages.EM0033));
                }

                if (!(await AddRoleToUser(request.UserName, RoleConstants.USER, cancellationToken)))
                {
                    throw ExceptionHelper.GenerateBusinessException(nameof(ErrorMessages.EM0033));
                }

                await transaction.CommitAsync(cancellationToken);
                return new SignupResponse();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
                _log.Error(message: "SIGNUP FAILED", ex, request: request);
                return new SignupResponse() { IsSuccess = false };
            }
        }

        private async Task<bool> InitUser(SignupRequest request, CancellationToken cancellationToken)
        {
            var newUser = new SquirrelUser
            { 
                InsertUserId = _currentUser?.Id??null,
                Email = request.Email,
                UserName = request.UserName,
            };

            var newUserResult = await _userManager.CreateAsync(newUser, request.Password);

            var userInfo = new UserInformation()
            {
                Name = request.Name,
                UserId = newUser.Id,
            };

            _dbContext.UserInformations.Add(userInfo);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return newUserResult.Succeeded;
        }

        private async Task<bool> AddRoleToUser(string userName, string role, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var addRoleResult = await _userManager.AddToRoleAsync(user, role);
            return addRoleResult.Succeeded;
        }

        private async Task<bool> InitDateToUser(string userName, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(userName);

            user.InsertDate = _now;
            user.UpdateDate = null;
            user.DeleteDate = null;
            user.UpdateUserId = null;
            user.InsertUserId = _currentUser?.Id ?? null;
            user.DeleteUserId = null;

            var addRoleResult = await _userManager.UpdateAsync(user);
            return addRoleResult.Succeeded;
        }
    }
}
