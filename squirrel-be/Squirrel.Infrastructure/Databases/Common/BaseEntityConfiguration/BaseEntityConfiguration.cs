using Squirrel.Infrastructure.Databases.Common.BaseEntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Squirrel.Infrastructure.Databases.Common.BaseEntityConfiguration
{
    public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(entity => entity.Id)
                .HasColumnName("Id")
                .HasColumnType("INT")
                .ValueGeneratedOnAdd()
                .HasComment("Khóa chính");

            builder.Property(entity => entity.InsertUserId)
                .HasColumnName("InsertUserId")
                .HasColumnType("INT");

            builder.Property(entity => entity.InsertDate)
                .HasColumnName("InsertDate")
                .HasColumnType("TIMESTAMP")
                .HasDefaultValueSql("NOW()");

            builder.Property(entity => entity.UpdateUserId)
                .HasColumnName("UpdateUserId")
                .HasColumnType("INT");

            builder.Property(entity => entity.UpdateDate)
                .HasColumnName("UpdateDate")
                .HasColumnType("TIMESTAMP")
                .HasDefaultValueSql("NOW()");

            builder.Property(entity => entity.DeleteUserId)
                .HasColumnName("DeleteUserId")
                .HasColumnType("INT");

            builder.Property(entity => entity.DeleteDate)
                .HasColumnName("DeleteDate")
                .HasColumnType("TIMESTAMP")
                .HasDefaultValueSql("NOW()");
            builder.Property(entity => entity.IsDeleted)
                .HasColumnName("IsDeleted")
                .HasColumnType("BOOL")
                .HasDefaultValueSql("false");

        }
    }
}
