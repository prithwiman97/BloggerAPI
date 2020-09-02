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
        public IActionResult Post([FromBody] Comment comment)
        {
            try
            {
                _context.Comments.Add(comment);
                _context.SaveChanges();
                return Ok("Comment added successfully");
            }
            catch(Exception e)
            {
                return BadRequest("Comment could not be added\n"+e);
            }
        }

        // PUT api/<CommentsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Comment comment)
        {
            try
            {
                Comment c = _context.Comments.Find(id);
                c.Content = comment.Content;
                c.DateOfPublish = comment.DateOfPublish;
                c.Username = comment.Username;
                c.BlogId = comment.BlogId;
                _context.Comments.Update(c);
                _context.SaveChanges();
                return Ok("Comment Updated");
            }
            catch (Exception e)
            {
                return BadRequest("Comment could not be updated\n" + e);
            }
        }

        // DELETE api/<CommentsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _context.Comments.Remove(_context.Comments.Find(id));
                _context.SaveChanges();
                return Ok("Comment deleted");
            }
            catch (Exception e)
            {
                return BadRequest("Comment could not be deleted\n" + e);
            }
        }
    }
}
