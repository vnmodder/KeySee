using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Squirrel.Infrastructure.Databases.Common.BaseEntityConfiguration;
using Squirrel.Infrastructure.Databases.SquirrelDB.Entities;

namespace Squirrel.Infrastructure.Databases.SquirrelDB.EntityConfigurations
{
    public class CategoryConfiguration : BaseEntityConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Name)
              .IsUnicode(true)
              .HasColumnName("Name");
            builder.Property(e => e.Description)
             .IsUnicode(true)
             .HasColumnName("Description");
            builder.Property(e => e.ImgUrl)
             .IsUnicode(true)
             .HasColumnName("ImgUrl");
        }
    }

}
