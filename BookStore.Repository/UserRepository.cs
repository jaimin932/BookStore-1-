using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models.ViewModels;
using BookStore.Models.NewFolder1;
namespace BookStore.Repository
{
    public class UserRepository : BaseRepository
    {

        public List<User> GetUsers(int pageIndex, int pagesize , string keyword)
        {
            var users = _context.Users.AsQueryable();

            if(pageIndex>0)
            {
                if(string.IsNullOrEmpty(keyword)==false)
                {
                    users = users.Where(w => w.FirstName.ToLower().Contains(keyword) || w.LastName.ToLower().Contains(keyword));
                }
                var userslist = users.Skip((pageIndex-1)*pagesize).Take(pagesize).ToList();
            }
            return _context.Users.ToList();
        }
        public User Login(LoginModel model)
        {
            return _context.Users.FirstOrDefault(c => c.Email.Equals(model.Email.ToLower()) && c.Password.Equals(model.Password));
        }
        public User Register(RegisterModel model)
        {
            User user = new User()
            {
                Email = model.Email,
                Password = model.Password,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Id = model.Id
            };
            var entry= _context.Users.Add(user);
            _context.SaveChanges();
            return entry.Entity;
        }

        public User GetUsers(int id)
        {
            if (id > 0)
            {
                return _context.Users.Where(w => w.Id == id).FirstOrDefault();
            }
            return null;
        }
        public bool UpdateUser(User model)
        {
            if(model.Id>0)
            {
                _context.Update(model);
                _context.SaveChanges();

                return true;
            }
            return false;
        }
        public bool DeleteUser(User model)
        {
            if (model.Id > 0)
            {
                _context.Remove(model);
                _context.SaveChanges();

                return true;
            }
            return false;
        }
    }
}
