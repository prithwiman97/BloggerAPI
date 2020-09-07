using BloggerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggerAPI.Interfaces
{
    public interface IUsers
    {
        public IEnumerable<Users> Get();
        public Users Get(string username);
        public string Post(Users user);
        public string Put(string username, Users user);
        public string Delete(string username);
    }
}
