using BloggerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggerAPI.Interfaces
{
    public interface IComment
    {
        public IEnumerable<Comment> Get();
        public IEnumerable<Comment> Get(int postId);
        public string Post(Comment comment);
        public string Put(int id, Comment comment);
        public string Delete(int id);
    }
}
