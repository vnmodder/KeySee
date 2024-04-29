using Squirrel.Infrastructure.Databases.Common.BaseEntityModels;

namespace Squirrel.Infrastructure.Databases.SquirrelDB.Entities
{
    public partial class Course : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? ImgUrl { get; set; }
        public int CategoryId { get; set; }
        public int CompletedLessons { get; set; }
        public int TotalLessons { get; set; }
    }
}
