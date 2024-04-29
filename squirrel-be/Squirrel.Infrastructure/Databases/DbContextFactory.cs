﻿using Squirrel.Infrastructure.Databases.CommandInterceptor;
using Squirrel.Infrastructure.Databases.SquirrelDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squirrel.Infrastructure.Databases
{
    public interface IDbContextFactory
    {
        /// <summary>
        /// Creates the key seeb context instance.
        /// </summary>
        /// <returns></returns>
        public SquirrelDbContext CreateSquirrelDbContextInstance();
    }
    public class DbContextFactory : IDbContextFactory
    {
        private readonly DbContextOptions<SquirrelDbContext> _squirrelDbContextOptions;

        public DbContextFactory(IConfiguration configuration)
        {
            if (!Directory.Exists($"{configuration["FtpServer:Directory"]}Logs/")){
                Directory.CreateDirectory($"{configuration["FtpServer:Directory"]}Logs/");
            }
            _squirrelDbContextOptions = new DbContextOptionsBuilder<SquirrelDbContext>()
                .AddInterceptors(new SquirrelDbContextCommandInterceptor($"{configuration["FtpServer:Directory"]}Logs/SquirrelDbContextSqlCommandLog.txt"))
                .UseSqlServer(
                    connectionString: configuration.GetConnectionString("SquirrelDB"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.CommandTimeout((int)TimeSpan.FromSeconds(SettingConstants.DatabaseSettings.TIMEOUT_FROM_SECONDS).TotalSeconds);
                        //sqlOptions.EnableRetryOnFailure();
                    })
                .EnableDetailedErrors()
                .Options;
        }

        public SquirrelDbContext CreateSquirrelDbContextInstance()
        {
            return new SquirrelDbContext(_squirrelDbContextOptions);
        }
    }
}
