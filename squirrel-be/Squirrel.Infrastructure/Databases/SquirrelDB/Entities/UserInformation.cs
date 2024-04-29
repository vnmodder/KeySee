using Squirrel.Infrastructure.Databases.Common.BaseEntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squirrel.Infrastructure.Databases.SquirrelDB.Entities
{
    public class UserInformation : BaseEntity
    {
        public string? Name { get; set; }
        public double Balance { get; set; }
        public int UserId { get; set; }
    }
}
