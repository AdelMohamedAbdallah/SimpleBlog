using Microsoft.EntityFrameworkCore;
using SimpleBlog.DAL.ConfigurationEntities;
using SimpleBlog.DAL.Entities;

namespace SimpleBlog.DAL.ConnectionData
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<BlogPost> BlogPosts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option)
            : base(option)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogPostTypeConfiguration).Assembly);
        }


    }
}
