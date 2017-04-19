using System;

namespace HandmadeItemMarket.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public DateTime DatePosted { get; set; }
    }
}