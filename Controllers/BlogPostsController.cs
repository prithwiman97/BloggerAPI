using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggerAPI.Models;
using BloggerAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BloggerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly BlogPostRepository _context;
        public BlogPostsController(BlogPostRepository context)
        {
            _context = context;
        }
        // GET: api/<BlogPostsController>
        [HttpGet]
        public IEnumerable<BlogPost> Get()
        {
            return _context.Get();
        }

        // GET api/<BlogPostsController>/5
        [HttpGet("{blogPostId}")]
        public IActionResult Get(int blogPostId)
        {
            BlogPost post = _context.Get(blogPostId);
            if (post == null)
                return BadRequest(post);
            return Ok(post);
        }

        // POST api/<BlogPostsController>
        [HttpPost]
        public string Post([FromBody] BlogPost post)
        {
            return _context.Post(post);
        }

        // PUT api/<BlogPostsController>/5
        [HttpPut("{blogPostId}")]
        public string Put(int blogPostId, [FromBody] BlogPost post)
        {
            return _context.Put(blogPostId, post);
        }

        // DELETE api/<BlogPostsController>/5
        [HttpDelete("{blogPostId}")]
        public string Delete(int blogPostId)
        {
            return _context.Delete(blogPostId);
        }
    }
}
