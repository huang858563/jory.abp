using jory.abp.Domain.Blog;
using jory.abp.Domain.HotNews;
using jory.abp.Domain.Wallpaper;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace jory.abp.EntityFrameworkCore
{
    [ConnectionStringName("Sqlite")]
    public class JoryAbpDbContext:AbpDbContext<JoryAbpDbContext>
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<FriendLink> FriendLinks { get; set; }
        public DbSet<Wallpaper> Wallpapers { get; set; }

        public DbSet<HotNews> HotNews { get; set; }

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
