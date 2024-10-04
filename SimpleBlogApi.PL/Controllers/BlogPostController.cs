using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.BLL.Models;
using SimpleBlog.BLL.Services;
using SimpleBlog.DAL.Entities;

namespace SimpleBlogApi.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogRepo blog;
        private readonly IMapper mapper;

        public BlogPostController(IBlogRepo blog, IMapper mapper)
        {
            this.blog = blog;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("~/api/BlogPost/GetBlogs")]
        public async Task<IActionResult> GetBlogs()
        {
            try
            {
                var data = await blog.GetAsync();

                var result = mapper.Map<IEnumerable<BlogPostVM>>(data);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error : {ex.Message}");
            }
        }


        [HttpGet]
        [Route("~/api/BlogPost/GetBlogBy/{id}")]
        public async Task<IActionResult> GetBlogBy(int id)
        {
            try
            {
                var data = await blog.GetByAsync(bl => bl.Id == id);

                var result = mapper.Map<BlogPostVM>(data);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error : {ex.Message}");
            }
        }


        [HttpPost]
        [Route("~/api/BlogPost/CreateBlog")]
        public async Task<IActionResult> CreateBlog(BlogPostVM Blog)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<BlogPost>(Blog);
                    await blog.CreateAsync(data);
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error : {ex.Message}");
            }
        }

        [HttpPut]
        [Route("~/api/BlogPost/UpdateBlog")]
        public async Task<IActionResult> UpdateBlog(BlogPostVM Blog)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<BlogPost>(Blog);
                    await blog.UpdateAsync(data);
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error : {ex.Message}");
            }
        }


        [HttpDelete]
        [Route("~/api/BlogPost/DeleteBlog")]
        public async Task<IActionResult> DeleteBlog(BlogPostVM Blog)
        {
            try
            {
                var data = mapper.Map<BlogPost>(Blog);
                await blog.DeleteAsync(data);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error : {ex.Message}");
            }
        }



    }
}
