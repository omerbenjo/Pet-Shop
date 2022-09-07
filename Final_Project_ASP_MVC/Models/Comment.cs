using System;
namespace Final_Project_ASP_MVC.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public Animal? Animal { get; set; }
        public int AnimalId { get; set; }
        public string? Content { get; set; }

    }
}

