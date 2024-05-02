using Newtonsoft.Json;
using Squirrel.Application.Authenticate.Login.Model;
using Squirrel.Infrastructure.Databases.SquirrelDB.Entities;

namespace Squirrel.Application.Authenticate.Login
{
    public class LoginResponse
    {
        public UserInfoModel? UserInfo { get; set; }
        public string? Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
        public IList<string> Roles { get; set; } = new List<string>();
        [JsonIgnore]
        public bool LoginSuccessFlag { get; set; }
    }
}
