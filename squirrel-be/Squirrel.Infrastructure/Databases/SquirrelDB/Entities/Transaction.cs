using Squirrel.Infrastructure.Common.Enums;
using Squirrel.Infrastructure.Databases.Common.BaseEntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squirrel.Infrastructure.Databases.SquirrelDB.Entities
{
    public class Transaction: BaseEntity
    {
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public TransactionType Type { get; set; }
        public int UserId { get; set; }
        public int? UserCourseId { get; set; }
        public string? Description { get; set; }
    }
}
