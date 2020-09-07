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
    public class BlogsController : ControllerBase
    {
        private readonly BlogRepository _context;
        public BlogsController(BlogRepository context)
        {
            _context = context;
        }
        // GET: api/<BlogsController>
        [HttpGet]
        public IEnumerable<Blog> Get()
        {
            return _context.Get();
        }

        // GET api/<BlogsController>/abcd123
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Blog blog = _context.Get(id);
            if (blog == null)
                return BadRequest(blog);
            return Ok(blog);
        }

        // POST api/<BlogsController>
        [HttpPost]
        public string Post([FromBody] Blog blog)
        {
            return _context.Post(blog);
        }

        // PUT api/<BlogsController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Blog blog)
        {
            return _context.Put(id, blog);
        }

        // DELETE api/<BlogsController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _context.Delete(id);
        }
    }
}
