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
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BlogPostsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
