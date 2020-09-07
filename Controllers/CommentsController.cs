using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggerAPI.Models;
using BloggerAPI.Repositories;
using log4net;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BloggerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        ILog logger = LogManager.GetLogger(typeof(UsersController));
        private readonly CommentRepository _context;
        public CommentsController(CommentRepository context)
        {
            _context = context;
        }
        // GET: api/<CommentsController>
        [HttpGet]
        public IEnumerable<Comment> Get()
        {
            return _context.Get();
        }

        // GET api/<CommentsController>/5  returns list of comments on a post with specified postId
        [HttpGet("{postId}")]
        public IEnumerable<Comment> Get(int postId)
        {
            return _context.Get(postId);
        }

        // POST api/<CommentsController>
        [HttpPost]
        public string Post([FromBody] Comment comment)
        {
            return _context.Post(comment);
        }

        // PUT api/<CommentsController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Comment comment)
        {
            return _context.Put(id, comment);
        }

        // DELETE api/<CommentsController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _context.Delete(id);
        }
    }
}
