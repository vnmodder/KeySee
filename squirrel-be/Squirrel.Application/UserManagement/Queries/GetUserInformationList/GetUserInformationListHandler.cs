using Squirrel.Application.Common.CQRS;
using Squirrel.Application.Common.Helpers;
using Squirrel.Application.Common.Interfaces;
using Squirrel.Application.UserManagement.Queries.GetUserInformationList.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Squirrel.Infrastructure.Databases;
using Squirrel.Infrastructure.Databases.SquirrelDB;
using Squirrel.Domain.Exceptions;
using Squirrel.Domain.Messages;

namespace Squirrel.Application.UserManagement.Queries.GetUserInformationList
{
    public class GetUserInformationListHandler : BaseCommandHandler<GetUserInformationListRequest, GetUserInformationListResponse>
    {
        private readonly IDbContextFactory _DbContextFactory;
        public GetUserInformationListHandler(
            SquirrelDbContext dbContext,
            IMapper mapper,
            IUserService userService,
            IDbContextFactory dbContextFactory,
            ILogService log) : base(dbContext, mapper, userService, log)
        {
            _DbContextFactory = dbContextFactory;
        }

        public override async Task<GetUserInformationListResponse> Handle(GetUserInformationListRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<UserInformationModel> users = await GetUserInformations();
                return new GetUserInformationListResponse() { Users = users };
            }
            catch (Exception ex)
            {
                _log.Error("Couldn't get data from database", ex, request);
                throw ExceptionHelper.GenerateBusinessException(nameof(ErrorMessages.EM0035), ex);
            }
        }

        public async Task<List<UserInformationModel>> GetUserInformations()
        {
            var query = from user in _dbContext.Users.AsNoTracking().Exist()
                        join userRole in _dbContext.UserRoles.AsNoTracking() on user.Id equals userRole.UserId
                        join role in _dbContext.Roles.AsNoTracking() on userRole.RoleId equals role.Id
                        orderby user.InsertDate
                        select new UserInformationModel
                        {
                            UserId = user.Id,
                            UserName = user.UserName,
                            RoleId = role.Id,
                            RoleName = role.Name,
                            UpdateDate = user.UpdateDate,
                            Mail = user.Email
                        };

            List<UserInformationModel> users = await query.ToListAsync();
            return users;
        }
    }
}
