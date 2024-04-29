using Squirrel.Application.Common.CQRS;
using Squirrel.Application.Common.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SquirrelUser = Squirrel.Infrastructure.Databases.SquirrelDB.Entities.User;
using Squirrel.Infrastructure.Databases.SquirrelDB;
using Squirrel.Domain.Exceptions;
using Squirrel.Domain.Messages;

namespace Squirrel.Application.UserManagement.Commands.DeleteUser
{
    public class DeleteUserHandler : BaseCommandHandler<DeleteUserCommand, DeleteUserResponse>
    {
        private readonly UserManager<SquirrelUser> _userManager;
        private SquirrelUser _currentUser;

        public DeleteUserHandler(
            SquirrelDbContext dbContext,
            IMapper mapper,
            IUserService userService,
            ILogService log,
            UserManager<SquirrelUser> userManager) : base(dbContext, mapper, userService, log)
        {
            _userManager = userManager;
            Task.Run(async () => {
                _currentUser = await _userManager.FindByNameAsync(_currentUserName);
            });
        }

        public override async Task<DeleteUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {

                var user = await _userManager.FindByNameAsync(request.UserName);

                if (user == null || user.Id == _currentUser?.Id )
                {
                    throw ExceptionHelper.GenerateBusinessException(nameof(ErrorMessages.EM0035));
                }

                user.DeleteDate = _now;
                user.DeleteUserId = _currentUser?.Id ?? null;
                
                var result = await _userManager.UpdateAsync(user);
                await _dbContext.SaveChangesAsync(cancellationToken);

                if (result.Succeeded)
                {
                    await transaction.CommitAsync(cancellationToken);
                    return new DeleteUserResponse();
                }
                else
                {
                    throw ExceptionHelper.GenerateBusinessException(nameof(ErrorMessages.EM0035));
                }
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
                _log.Error("Delete an user FAILED", ex, request);
                throw ExceptionHelper.GenerateBusinessException(nameof(ErrorMessages.EM0035), ex);
            }
        }
    }
}
