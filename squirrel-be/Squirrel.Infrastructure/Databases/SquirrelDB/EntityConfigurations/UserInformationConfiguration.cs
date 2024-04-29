using Squirrel.Infrastructure.Databases.SquirrelDB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Squirrel.Infrastructure.Databases.SquirrelDB.EntityConfigurations
{
    public class UserInformationConfiguration : IEntityTypeConfiguration<UserInformation>
    {
        public void Configure(EntityTypeBuilder<UserInformation> builder)
        {
            builder.Property(entity => entity.Name)
                .IsRequired()
                .HasColumnName("Name");

            builder.Property(entity => entity.Balance)
                .HasColumnName("Balance")
                .HasColumnType("INT")
                .HasComment("Balance");

            builder.Property(entity => entity.UserId)
                .HasColumnName("UserId")
                .HasColumnType("INT")
                .HasComment("UserId");
        }
    }
}
