using Squirrel.Infrastructure.Databases.SquirrelDB.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Squirrel.Infrastructure.Databases.Common.BaseEntityConfiguration;

namespace Squirrel.Infrastructure.Databases.SquirrelDB.EntityConfigurations
{
    public class CourseConfiguration : BaseEntityConfiguration<Course>
    {
        public override void Configure(EntityTypeBuilder<Course> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Title)
              .IsUnicode(true)
              .HasColumnName("Title");
            builder.Property(e => e.Description)
             .IsUnicode(true)
             .HasColumnName("Description");
            builder.Property(e => e.ImgUrl)
             .IsUnicode(true)
             .HasColumnName("ImgUrl");
            builder.Property(e => e.Price)
             .HasColumnType("DECIMAL")
             .HasColumnName("Price");

            builder.Property(e => e.CategoryId)
             .HasColumnType("INT")
             .HasColumnName("CategoryId");
            builder.Property(e => e.TotalLessons)
             .HasColumnType("INT")
             .HasColumnName("TotalLessons");
            builder.Property(e => e.CompletedLessons)
             .HasColumnType("INT")
             .HasColumnName("CompletedLessons");

        }
    }
}
