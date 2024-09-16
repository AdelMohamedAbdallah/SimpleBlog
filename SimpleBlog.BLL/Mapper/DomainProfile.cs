using AutoMapper;
using SimpleBlog.BLL.Models;
using SimpleBlog.DAL.Entities;

namespace SimpleBlog.BLL.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<BlogPost, BlogPostVM>();
            CreateMap<BlogPostVM, BlogPost>();
        }
    }
}
