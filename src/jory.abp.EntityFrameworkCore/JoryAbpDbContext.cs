using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using jory.abp.Domain.Blog;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace jory.abp.EntityFrameworkCore
{
    [ConnectionStringName("SqlServer")]
    public class JoryAbpDbContext:AbpDbContext<JoryAbpDbContext>
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<FriendLink> FriendLinks { get; set; }

        public JoryAbpDbContext(DbContextOptions<JoryAbpDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configure();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
