using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace jory.abp.EntityFrameworkCore.DbMigrations.EntityFrameworkCore
{
    public class JoryAbpMigrationsDbContext : AbpDbContext<JoryAbpMigrationsDbContext>
    {
        public JoryAbpMigrationsDbContext(DbContextOptions<JoryAbpMigrationsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Configure();
        }
    }
}
