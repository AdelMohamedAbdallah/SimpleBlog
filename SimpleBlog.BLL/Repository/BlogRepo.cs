using Microsoft.EntityFrameworkCore;
using SimpleBlog.BLL.Services;
using SimpleBlog.DAL.ConnectionData;
using SimpleBlog.DAL.Entities;
using System.Linq.Expressions;

namespace SimpleBlog.BLL.Repository
{
    public class BlogRepo : IBlogRepo
    {
        private readonly ApplicationDbContext db;

        public BlogRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(BlogPost blogPost)
        {
            blogPost.CreatedDate = DateTime.Now;
            await db.BlogPosts.AddAsync(blogPost);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(BlogPost blogPost)
        {
            db.BlogPosts.Remove(blogPost);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<BlogPost>> GetAsync(Expression<Func<BlogPost, bool>> filter = null)
        {
            if (filter is null)
            {
                var data = await db.BlogPosts.AsNoTracking().ToListAsync();
                return data;
            }
            else
            {
                var data = await db.BlogPosts.AsNoTracking().Where(filter).ToListAsync();
                return data;
            }


        }

        public async Task<BlogPost> GetByAsync(Expression<Func<BlogPost, bool>> filter)
        {
            var data = await db.BlogPosts.AsNoTracking()
                                         .Where(filter)
                                         .FirstOrDefaultAsync();
            if (data == null)
                throw new ArgumentNullException("InValid Data");
            return data;
        }


        public async Task UpdateAsync(BlogPost blogPost)
        {
            db.Entry(blogPost).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
