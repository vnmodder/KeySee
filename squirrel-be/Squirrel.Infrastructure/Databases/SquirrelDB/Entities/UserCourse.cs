using Squirrel.Infrastructure.Databases.Common.BaseEntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squirrel.Infrastructure.Databases.SquirrelDB.Entities
{
    public class UserCourse :BaseEntity
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public DateTime Date { get; set; }
    }
}
