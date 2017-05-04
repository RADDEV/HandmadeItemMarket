using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HandmadeItemMarket.Models.EntityModels
{
    public class BlogPost
    {
        public BlogPost()
        {
            this.Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }
        public virtual ApplicationUser Poster { get; set; }
        public DateTime DatePosted { get; set; }
        public string Image { get; set; }
        [Required,MinLength(3)]
        public string Title { get; set; }
        [Required, MinLength(3)]
        public string Content { get; set; }
        public int Rating { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}