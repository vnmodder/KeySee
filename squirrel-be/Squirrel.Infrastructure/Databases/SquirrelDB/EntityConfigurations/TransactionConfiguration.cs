using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Squirrel.Infrastructure.Databases.Common.BaseEntityConfiguration;
using Squirrel.Infrastructure.Databases.SquirrelDB.Entities;

namespace Squirrel.Infrastructure.Databases.SquirrelDB.EntityConfigurations
{
    public class TransactionConfiguration : BaseEntityConfiguration<Transaction>
    {
        public override void Configure(EntityTypeBuilder<Transaction> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Date)
              .HasColumnType("TIMESTAMP")
              .HasColumnName("Date");
            builder.Property(e => e.Amount)
             .HasColumnType("DECIMAL")
             .HasColumnName("Amount");
            builder.Property(e => e.Type)
             .HasColumnType("INT")
             .HasColumnName("Type");
            builder.Property(e => e.UserId)
             .HasColumnType("INT")
             .HasColumnName("UserId");
            builder.Property(e => e.UserCourseId)
             .HasColumnType("INT")
             .HasColumnName("UserCourseId");
            builder.Property(e => e.Description)
             .IsUnicode(true)
             .HasColumnName("Description");
        }
    }
}
