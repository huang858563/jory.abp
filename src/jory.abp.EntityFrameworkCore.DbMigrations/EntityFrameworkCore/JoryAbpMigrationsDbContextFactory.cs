using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace jory.abp.EntityFrameworkCore.DbMigrations.EntityFrameworkCore
{
    public class JoryAbpMigrationsDbContextFactory : IDesignTimeDbContextFactory<JoryAbpMigrationsDbContext>
    {
        public JoryAbpMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<JoryAbpMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new JoryAbpMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
