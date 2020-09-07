using BloggerAPI.Interfaces;
using BloggerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggerAPI.Repositories
{
    public class UsersRepository:IUsers
    {
        private readonly BloggerContext _context;
        public UsersRepository(BloggerContext context)
        {
            _context = context;
        }
       
        public IEnumerable<Users> Get()
        {
            return _context.Users.ToList();
        }

        public Users Get(string username)
        {
            IQueryable<Users> user = _context.Users.Where(u => u.Username == username);
            if (user.Count() > 0)
                return user.FirstOrDefault();
            return null;
        }

        public string Post(Users user)
        {
            _context.Users.Add(user);
            try
            {
                _context.SaveChanges();
                return "User Added Successfully";
            }
            catch (Exception e)
            {
                return "User could not be added";
            }
        }

        public string Put(string username, Users user)
        {
            IQueryable<Users> users = _context.Users.Where(u => u.Username == username);
            if (users.Count() > 0)
            {
                Users found = users.FirstOrDefault();
                found.Firstname = user.Firstname;
                found.Lastname = user.Lastname;
                found.DOB = user.DOB;
                if (user.Password != null)
                    found.Password = user.Password;
                _context.Users.Update(found);
                _context.SaveChanges();
                return "User updated";
            }
            return "User could not be updated";
        }

        public string Delete(string username)
        {
            IQueryable<Users> user = _context.Users.Where(u => u.Username == username);
            if (user.Count() > 0)
            {
                _context.Users.Remove(user.FirstOrDefault());
                _context.SaveChanges();
                return "User deleted successfully";
            }
            return "User could not be deleted";
        }
    }
}
