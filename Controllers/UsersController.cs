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
    public class UsersController : ControllerBase
    {
        private readonly BloggerContext _context;
        public UsersController(BloggerContext context)
        {
            _context = context;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Users.ToList());
        }

        // GET api/<UsersController>/abcd123
        [HttpGet("{username}")]
        public IActionResult Get(string username)
        {
            Users user = _context.Users.Find(username);
            if (user != null)
                return Ok(user);
            return BadRequest(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] Users user)
        {
            _context.Users.Add(user);
            try
            {
                _context.SaveChanges();
                return Ok("User Added Successfully");
            }
            catch(Exception e) {
                return BadRequest("User could not be added\n"+e);
            }
        }

        // PUT api/<UsersController>/abcd123
        [HttpPut("{username}")]
        public IActionResult Put(string username, [FromBody] Users user)
        {
            try
            {
                Users u = _context.Users.Find(username);
                u.Firstname = user.Firstname;
                u.Lastname = user.Lastname;
                u.DOB = user.DOB;
                if (user.Password != null)
                    u.Password = user.Password;
                _context.Users.Update(u);
                _context.SaveChanges();
                return Ok("User updated");
            }
            catch(Exception e)
            {
                return BadRequest("User could not be updated\n"+e);
            }
        }

        // DELETE api/<UsersController>/abcd123
        [HttpDelete("{username}")]
        public IActionResult Delete(string username)
        {
            try
            {
                _context.Users.Remove(_context.Users.Find(username));
                _context.SaveChanges();
                return Ok("User deleted successfully");
            }
            catch(Exception e)
            {
                return BadRequest("User could not be deleted\n" + e);
            }
        }
    }
}
