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
    public class CommentsController : ControllerBase
    {
        private readonly BloggerContext _context;
        public CommentsController(BloggerContext context)
        {
            _context = context;
        }
        // GET: api/<CommentsController>
        [HttpGet]
        public IEnumerable<Comment> Get()
        {
            return _context.Comments.ToList();
        }

        // GET api/<CommentsController>/5
        [HttpGet("{blogId}")]
        public IEnumerable<Comment> Get(int blogId)
        {
            IEnumerable<Comment> comments = _context.Comments.ToList();
            comments = from c in comments where c.BlogId == blogId select c;
            return comments;
        }

        // POST api/<CommentsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CommentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CommentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
