using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleBlog.DAL.Entities;

namespace SimpleBlog.DAL.ConfigurationEntities
{
    internal class BlogPostTypeConfiguration : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.HasKey(bp => bp.Id);

            builder.Property(bp => bp.Title).HasMaxLength(100);

            builder.Property(bp => bp.AutherName).HasMaxLength(50);

            builder.Property(bp => bp.CreatedDate).HasDefaultValue(DateTime.Now);

            builder.ToTable("BlogPosts");
        }
    }
}
