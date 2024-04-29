using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Squirrel.Infrastructure.Databases.Common.BaseEntityConfiguration;
using Squirrel.Infrastructure.Databases.SquirrelDB.Entities;

namespace Squirrel.Infrastructure.Databases.SquirrelDB.EntityConfigurations
{
    public class LessonConfiguration : BaseEntityConfiguration<Lesson>
    {
        public override void Configure(EntityTypeBuilder<Lesson> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Title)
              .IsUnicode(true)
              .HasColumnName("Title");
            builder.Property(e => e.VideoUrl)
             .IsUnicode(true)
             .HasColumnName("VideoUrl");
            builder.Property(e => e.Content)
             .IsUnicode(true)
             .HasColumnName("Content");
            builder.Property(e => e.ImgUrl)
             .IsUnicode(true)
             .HasColumnName("ImgUrl");
            builder.Property(e => e.IsCompleted)
             .HasColumnType("BIT")
             .HasColumnName("IsCompleted");
        }
    }

}
