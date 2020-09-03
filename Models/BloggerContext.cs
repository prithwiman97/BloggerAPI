using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggerAPI.Models
{
    public class BloggerContext:DbContext
    {
        public BloggerContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
