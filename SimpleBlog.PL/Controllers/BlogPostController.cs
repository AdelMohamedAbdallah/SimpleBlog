using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.BLL.Models;
using SimpleBlog.BLL.Services;
using SimpleBlog.DAL.Entities;

namespace SimpleBlog.PL.Controllers
{
    public class BlogPostController : Controller
    {
        private readonly IBlogRepo blogRepo;
        private readonly IMapper mapper;

        public BlogPostController(IBlogRepo blogRepo, IMapper mapper)
        {
            this.blogRepo = blogRepo;
            this.mapper = mapper;
        }

        public async Task<IActionResult> GetData(string titlesearch)
        {
            if (titlesearch == null)
            {
                var data = await blogRepo.GetAsync();
                var result = mapper.Map<IEnumerable<BlogPostVM>>(data);
                return View(result);
            }
            else
            {
                var data = await blogRepo.GetAsync(bp => bp.Title.Contains(titlesearch));
                var result = mapper.Map<IEnumerable<BlogPostVM>>(data);
                return View(result);
            }

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogPostVM blogPost)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<BlogPost>(blogPost);
                    await blogRepo.CreateAsync(data);
                    return RedirectToAction("GetData");
                }
                return View(blogPost);
            }
            catch (Exception ex)
            {
                return View(blogPost);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Detalis(int id)
        {
            try
            {
                var data = await blogRepo.GetByAsync(bp => bp.Id == id);
                var result = mapper.Map<BlogPostVM>(data);
                return View(result);
            }
            catch (Exception ex)
            {
                return View($"Error : {ex.Message}");
            }

        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var data = await blogRepo.GetByAsync(bp => bp.Id == id);
            var result = mapper.Map<BlogPostVM>(data);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(BlogPostVM blogPost)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<BlogPost>(blogPost);
                    await blogRepo.UpdateAsync(data);
                    return RedirectToAction("GetData");
                }
                return View(blogPost);
            }
            catch
            {
                return View(blogPost);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await blogRepo.GetByAsync(bp => bp.Id == id);
            var result = mapper.Map<BlogPostVM>(data);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(BlogPostVM blogPost)
        {
            try
            {
                var data = mapper.Map<BlogPost>(blogPost);
                await blogRepo.DeleteAsync(data);
                return RedirectToAction("GetData");
            }
            catch (Exception ex)
            {
                return View(blogPost);
            }
        }

        public IActionResult About()
        {
            return View();
        }


    }
}
