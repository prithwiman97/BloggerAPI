using BloggerAPI.Interfaces;
using BloggerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggerAPI.Repositories
{
    public class BlogRepository:IBlog
    {
        private readonly BloggerContext _context;
        public BlogRepository(BloggerContext context)
        {
            _context = context;
        }
        public IEnumerable<Blog> Get()
        {
            return _context.Blogs.ToList();
        }

        public Blog Get(int id)
        {
            IQueryable<Blog> blogs = _context.Blogs.Where(b => b.Id == id);
            if (blogs.Count() > 0)
                return blogs.FirstOrDefault();
            return null;
        }

        public string Post(Blog blog)
        {
            try
            {
                _context.Blogs.Add(blog);
                _context.SaveChanges();
                return "Blog published successfully";
            }
            catch (Exception e)
            {
                return "Blog could not be added";
            }
        }

        public string Put(int id, Blog blog)
        {
            IQueryable<Blog> blogs = _context.Blogs.Where(b => b.Id == id);
            if (blogs.Count() > 0)
            {
                Blog b = blogs.FirstOrDefault();
                b.Title = blog.Title;
                b.Description = blog.Description;
                b.DateOfPublish = blog.DateOfPublish;
                b.Type = blog.Type;
                b.Username = blog.Username;
                _context.Blogs.Update(b);
                _context.SaveChanges();
                return "Blog Updated";
            }
            return "Blog could not be updated";
        }

        public string Delete(int id)
        {
            IQueryable<Blog> blogs = _context.Blogs.Where(b => b.Id == id);
            if (blogs.Count() > 0)
            {
                _context.Blogs.Remove(_context.Blogs.Find(id));
                _context.SaveChanges();
                return "Blog deleted";
            }
            return "Blog could not be deleted";
        }
    }
}
