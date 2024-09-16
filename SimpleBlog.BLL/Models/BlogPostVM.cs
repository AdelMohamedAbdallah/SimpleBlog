using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.BLL.Models
{
    public class BlogPostVM
    {
        public int Id { get; set; }
        [StringLength(100, ErrorMessage = "Max Length 100 Character")]
        public string Title { get; set; }
        public string Content { get; set; }
        [StringLength(100, ErrorMessage = "Max Length 50 Character")]
        public string AutherName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
