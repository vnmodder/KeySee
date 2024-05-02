using AutoMapper;
using Squirrel.Application.Authenticate.Login.Model;
using Squirrel.Infrastructure.Databases.SquirrelDB.Entities;

namespace Application.Common.MappingProfiles
{
    public class ApproveDataProfile : Profile
    {
        public ApproveDataProfile()
        {
            CreateMap<UserInformation, UserInfoModel>();
        }
    }
}
