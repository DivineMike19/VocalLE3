using System;

namespace BlogDataLibrary.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Body { get; set; } = "";
        public string Username { get; set; } = "";
        public DateTime DateCreated { get; set; }
    }
}
