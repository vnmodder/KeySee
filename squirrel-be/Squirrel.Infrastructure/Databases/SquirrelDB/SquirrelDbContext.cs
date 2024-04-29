using Squirrel.Infrastructure.Databases.SquirrelDB.Entities;
using Squirrel.Infrastructure.Databases.SquirrelDB.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squirrel.Infrastructure.Databases.SquirrelDB
{
    public partial class SquirrelDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public SquirrelDbContext(DbContextOptions<SquirrelDbContext> options)
     : base(options)
        {
        }

        #region DbSet declarations.
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<UserCourse> UserCourses { get; set; }
        public virtual DbSet<UserInformation> UserInformations { get; set; }
        #endregion

        #region PORE Database Views
        //public virtual DbSet<ViewTotalConsumptionTaxPerTenant> ViewTotalConsumptionTaxPerTenants { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.UseCollation("Japanese_CI_AS");

            // Apply configuration off IdentityDbContext.
            base.OnModelCreating(modelBuilder);

            // Configure the Id column for AspNetUsers table. Set max length to 50.
            //modelBuilder.Entity<User>().Property(u => u.Id)
            //    .HasColumnType("NVARCHAR")
            //    .HasMaxLength(7);

            // Configure the Id column for AspNetRoles table. Set max length to 50.
            //modelBuilder.Entity<IdentityRole<string>>().Property(u => u.Id)
            //    .HasColumnType("NVARCHAR")
            //    .HasMaxLength(7);

            // Add dumydata
            modelBuilder.AddDummyData();

            // OnModelCreatingPartial(modelBuilder);
            // Apply all configurations that have attached to DbContext.DbSets.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SquirrelDbContext).Assembly, entity => entity.Namespace.Contains("SquirrelDB"));
        }
    }
}
