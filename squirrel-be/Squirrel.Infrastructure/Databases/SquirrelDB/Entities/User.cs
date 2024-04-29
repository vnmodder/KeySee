using Microsoft.AspNetCore.Identity;

namespace Squirrel.Infrastructure.Databases.SquirrelDB.Entities
{
    public partial class User : IdentityUser<int>
    {
        public int? InsertUserId { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? DeleteUserId { get; set; } = null;
        public DateTime? DeleteDate { get; set; } = null;
        public int Status {  get; set; } = 0;

    }
}
