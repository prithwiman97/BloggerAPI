using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggerAPI.Models
{
    public class BloggerContext:DbContext
    {
        public BloggerContext()
        {

        }
        public BloggerContext(DbContextOptions options):base(options)
        {
        }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<BlogPost> BlogPosts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
    }
}
