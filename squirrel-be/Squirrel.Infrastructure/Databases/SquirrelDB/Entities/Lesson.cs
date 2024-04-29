using Squirrel.Infrastructure.Databases.Common.BaseEntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squirrel.Infrastructure.Databases.SquirrelDB.Entities
{
    public class Lesson : BaseEntity
    {
        public string? Title { get; set; }
        public string? VideoUrl { get; set; }
        public string? Content { get; set; }
        public string? ImgUrl { get; set; }
        public bool IsCompleted { get; set; }
    }
}
