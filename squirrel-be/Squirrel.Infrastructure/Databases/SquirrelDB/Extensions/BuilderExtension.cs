using Squirrel.Infrastructure.Constants;
using Squirrel.Infrastructure.Databases.SquirrelDB.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squirrel.Infrastructure.Databases.SquirrelDB.Extensions
{
    public static class BuilderExtension
    {
        public static void AddDummyData(this ModelBuilder modelBuilder)
        {
            //add default for Role
            var roles = new List<IdentityRole<int>>()
            {
                new IdentityRole<int>() { Id = 1, Name = RoleConstants.ZERO, ConcurrencyStamp = "1", NormalizedName = RoleConstants.ZERO},
                new IdentityRole<int>() { Id = 2, Name = RoleConstants.ADMIN, ConcurrencyStamp = "2", NormalizedName = RoleConstants.ADMIN },
                new IdentityRole<int>() { Id = 3, Name = RoleConstants.USER, ConcurrencyStamp = "3", NormalizedName = RoleConstants.USER }
            };

            modelBuilder.Entity<IdentityRole<int>>()
                .HasData(roles);
        }
    }
}
