using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggerAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BloggerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly BloggerContext _context;
        public BlogsController(BloggerContext context)
        {
            _context = context;
        }
        // GET: api/<BlogsController>
        [HttpGet]
        public IEnumerable<Blog> Get()
        {
            return _context.Blogs.ToList();
        }

        // GET api/<BlogsController>/abcd123
        [HttpGet("{username}")]
        public IEnumerable<Blog> Get(string username)
        {
            IEnumerable<Blog> blogs = _context.Blogs.ToList();
            blogs = from b in blogs where b.Username == username select b;
            return blogs;
        }

        // POST api/<BlogsController>
        [HttpPost]
        public IActionResult Post([FromBody] Blog blog)
        {
            try
            {
                _context.Blogs.Add(blog);
                _context.SaveChanges();
                return Ok("Blog published successfully");
            }
            catch(Exception e)
            {
                return BadRequest("Blog could not be added\n" + e);
            }
        }

        // PUT api/<BlogsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Blog blog)
        {
            try
            {
                Blog b = _context.Blogs.Find(id);
                b.Content = blog.Content;
                b.DateOfPublish = blog.DateOfPublish;
                b.Type = blog.Type;
                b.Username = blog.Username;
                _context.Update(b);
                _context.SaveChanges();
                return Ok("Blog Updated");
            }
            catch(Exception e)
            {
                return BadRequest("Blog could not be updated\n"+e);
            }
        }

        // DELETE api/<BlogsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _context.Blogs.Remove(_context.Blogs.Find(id));
                _context.SaveChanges();
                return Ok("Blog deleted");
            }
            catch(Exception e)
            {
                return BadRequest("Blog could not be deleted\n" + e);
            }
        }
    }
}
