using System;
using System.ComponentModel.DataAnnotations;

namespace HandmadeItemMarket.Models.EntityModels
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public int Rating { get; set; }
        public DateTime DatePosted { get; set; }
        public virtual ApplicationUser Poster { get; set; }
    }
}