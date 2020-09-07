using BloggerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggerAPI.Interfaces
{
    public interface IBlog
    {
        public IEnumerable<Blog> Get();
        public Blog Get(int id);
        public string Post(Blog blog);
        public string Put(int id, Blog blog);
        public string Delete(int id);
    }
}
