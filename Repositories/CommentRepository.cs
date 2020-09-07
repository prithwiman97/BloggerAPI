using BloggerAPI.Interfaces;
using BloggerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggerAPI.Repositories
{
    public class CommentRepository:IComment
    {
        private readonly BloggerContext _context;
        public CommentRepository(BloggerContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Comment> Get()
        {
            return _context.Comments.ToList();
        }

      
        public IEnumerable<Comment> Get(int postId)
        {
            IEnumerable<Comment> comments = _context.Comments.ToList();
            comments = from c in comments where c.PostId == postId select c;
            return comments;
        }

        
        public string Post(Comment comment)
        {
            try
            {
                _context.Comments.Add(comment);
                _context.SaveChanges();
                return "Comment added successfully";
            }
            catch (Exception e)
            {
                return "Comment could not be added";
            }
        }

        
        public string Put(int id, Comment comment)
        {
            IQueryable<Comment> comments = _context.Comments.Where(c => c.Id == id);
            if (comments.Count() > 0)
            {
                Comment c = comments.FirstOrDefault();
                c.Content = comment.Content;
                c.DateOfPublish = comment.DateOfPublish;
                c.Username = comment.Username;
                c.PostId = comment.PostId;
                _context.Comments.Update(c);
                _context.SaveChanges();
                return "Comment Updated";
            }
            return "Comment could not be updated";
        }

        public string Delete(int id)
        {
            IQueryable<Comment> comments = _context.Comments.Where(c => c.Id == id);
            if (comments.Count() > 0)
            {
                _context.Comments.Remove(comments.FirstOrDefault());
                _context.SaveChanges();
                return "Comment deleted";
            }
            return "Comment could not be deleted";
        }
    }
}
