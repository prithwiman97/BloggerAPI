using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using log4net;
using BloggerAPI.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BloggerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersRepository _context;
        ILog logger = LogManager.GetLogger(typeof(UsersController));
        public UsersController(UsersRepository repo)
        {
            _context = repo;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Get());
        }

        // GET api/<UsersController>/abcd123
        [HttpGet("{username}")]
        public IActionResult Get(string username)
        {
            Users user = _context.Get(username);
            if(user == null)
                return BadRequest(user);
            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public string Post([FromBody] Users user)
        {
            return _context.Post(user);
        }

        // PUT api/<UsersController>/abcd123
        [HttpPut("{username}")]
        public string Put(string username, [FromBody] Users user)
        {
            return _context.Put(username, user);
        }

        // DELETE api/<UsersController>/abcd123
        [HttpDelete("{username}")]
        public string Delete(string username)
        {
            return _context.Delete(username);
        }
    }
}
