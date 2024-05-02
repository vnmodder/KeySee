using Squirrel.Infrastructure.Databases.SquirrelDB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Squirrel.Infrastructure.Databases.SquirrelDB.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(entity => entity.InsertUserId)
                .HasColumnName("InsertUserId")
                .HasColumnType("INT")
                .HasComment("InsertUserId");

            builder.Property(entity => entity.InsertDate)
                .HasColumnName("InsertDate")
                .HasColumnType("TIMESTAMP")
                .HasDefaultValueSql("NOW()")
                .HasComment("InsertDate");

            builder.Property(entity => entity.UpdateUserId)
                .HasColumnName("UpdateUserId")
                .HasColumnType("INT")
                .HasComment("UpdateUserId");

            builder.Property(entity => entity.UpdateDate)
                .HasColumnName("UpdateDate")
                .HasColumnType("TIMESTAMP")
                .HasDefaultValueSql("NOW()")
                .HasComment("UpdateDate");

            builder.Property(entity => entity.DeleteUserId)
                .HasColumnName("DeleteUserId")
                .HasColumnType("INT")
                .HasComment("DeleteUserId");

            builder.Property(entity => entity.DeleteDate)
                .HasColumnName("DeleteDate")
                .HasColumnType("TIMESTAMP")
                .HasDefaultValueSql("NOW()")
                .HasComment("DeleteDate");

            builder.Property(entity => entity.Status)
              .HasColumnName("Status")
              .HasColumnType("INT")
              .HasComment("Status");
        }
    }
}
