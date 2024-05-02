using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Squirrel.Infrastructure.Databases.Common.BaseEntityConfiguration;
using Squirrel.Infrastructure.Databases.SquirrelDB.Entities;

namespace Squirrel.Infrastructure.Databases.SquirrelDB.EntityConfigurations
{
    public class UserCourseConfiguration : BaseEntityConfiguration<UserCourse>
    {
        public override void Configure(EntityTypeBuilder<UserCourse> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.UserId)
              .HasColumnType("INT")
              .HasColumnName("UserId");
            builder.Property(e => e.CourseId)
             .HasColumnType("INT")
             .HasColumnName("CourseId");
            builder.Property(e => e.Date)
             .HasColumnType("TIMESTAMP")
             .HasColumnName("Date");
        }
    }
}

