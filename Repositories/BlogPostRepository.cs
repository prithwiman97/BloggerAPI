using BloggerAPI.Interfaces;
using BloggerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggerAPI.Repositories
{
    public class BlogPostRepository:IBlogPost
    {
        private readonly BloggerContext _context;
        public BlogPostRepository(BloggerContext context)
        {
            _context = context;
        }

        public IEnumerable<BlogPost> Get()
        {
            return _context.BlogPosts.ToList();
        }

        
        public BlogPost Get(int blogPostId)
        {
            IQueryable<BlogPost> posts = _context.BlogPosts.Where(p => p.Id == blogPostId);
            if (posts.Count() > 0)
                return posts.FirstOrDefault();
            return null;
        }

        
        public string Post(BlogPost post)
        {
            try
            {
                _context.BlogPosts.Add(post);
                _context.SaveChanges();
                return "Blog Post Added";
            }
            catch (Exception e)
            {
                return "Blog Post could not be added";
            }
        }

        
        public string Put(int blogPostId, BlogPost post)
        {
            IQueryable<BlogPost> posts = _context.BlogPosts.Where(p => p.Id == blogPostId);
            if (posts.Count() > 0)
            {
                BlogPost p = posts.FirstOrDefault();
                p.Title = post.Title;
                p.Content = post.Content;
                p.DateOfPublish = post.DateOfPublish;
                p.BlogId = post.BlogId;
                _context.BlogPosts.Update(p);
                _context.SaveChanges();
                return "Post updated successfully";
            }
            return "Post could not be updated";
        }

        
        public string Delete(int blogPostId)
        {
            IQueryable<BlogPost> posts = _context.BlogPosts.Where(p => p.Id == blogPostId);
            if (posts.Count() > 0)
            {
                _context.BlogPosts.Remove(posts.FirstOrDefault());
                _context.SaveChanges();
                return "Post deleted successfully";
            }
            return "Post could not be deleted";
        }
    }
}
