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
    public class BlogPostsController : ControllerBase
    {
        private readonly BloggerContext _context;
        public BlogPostsController(BloggerContext context)
        {
            _context = context;
        }
        // GET: api/<BlogPostsController>
        [HttpGet]
        public IEnumerable<BlogPost> Get()
        {
            return _context.BlogPosts.ToList();
        }

        // GET api/<BlogPostsController>/5
        [HttpGet("{blogId}")]
        public IEnumerable<BlogPost> Get(int blogId)
        {
            IEnumerable<BlogPost> posts = _context.BlogPosts.ToList();
            posts = from p in posts where p.BlogId == blogId select p;
            return posts;
        }

        // POST api/<BlogPostsController>
        [HttpPost]
        public IActionResult Post([FromBody] BlogPost post)
        {
            try
            {
                _context.BlogPosts.Add(post);
                _context.SaveChanges();
                return Ok("Blog Post Added");
            }
            catch(Exception e)
            {
                return BadRequest("Blog Post could not be added\n" + e);
            }
        }

        // PUT api/<BlogPostsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BlogPost post)
        {
            BlogPost p = _context.BlogPosts.Find(id);
            p.Title = post.Title;
            p.Content = post.Content;
            p.DateOfPublish = post.DateOfPublish;
            p.BlogId = post.BlogId;
            try
            {
                _context.BlogPosts.Update(p);
                _context.SaveChanges();
                return Ok("Post updated successfully");
            }
            catch(Exception e)
            {
                return BadRequest("Post could not be updated\n" + e);
            }
        }

        // DELETE api/<BlogPostsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _context.BlogPosts.Remove(_context.BlogPosts.Find(id));
                _context.SaveChanges();
                return Ok("Post deleted successfully");
            }
            catch(Exception e)
            {
                return BadRequest("Post could not be deleted\n" + e);
            }
        }
    }
}
