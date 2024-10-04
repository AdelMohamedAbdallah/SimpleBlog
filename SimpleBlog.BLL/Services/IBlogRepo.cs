
using SimpleBlog.DAL.Entities;
using System.Linq.Expressions;

namespace SimpleBlog.BLL.Services
{
    public interface IBlogRepo
    {
        Task<IEnumerable<BlogPost>> GetAsync(Expression<Func<BlogPost, bool>>? filter = null);
        Task<BlogPost> GetByAsync(Expression<Func<BlogPost, bool>> filter);
        Task CreateAsync(BlogPost blogPost);
        Task UpdateAsync(BlogPost blogPost);
        Task DeleteAsync(BlogPost blogPost);
    }
}
