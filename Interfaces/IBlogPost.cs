using BloggerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggerAPI.Interfaces
{
    public interface IBlogPost
    {
        public IEnumerable<BlogPost> Get();
        public BlogPost Get(int blogId);
        public string Post(BlogPost post);
        public string Put(int blogPostId, BlogPost post);
        public string Delete(int blogPostId);
    }
}
