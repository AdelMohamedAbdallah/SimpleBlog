namespace SimpleBlog.DAL.Entities
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string AutherName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
