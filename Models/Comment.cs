using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggerAPI.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateOfPublish { get; set; }
        public string Username { get; set; }
        public int BlogId { get; set; }
    }
}
