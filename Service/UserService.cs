using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using bookAPI.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace bookAPI.Service
{
    public class UserService
    {
        public WebBookContext dbContext {get; set;}
        public UserService() 
        {
            dbContext = new WebBookContext();
        }

        public IEnumerable<User> Get()
        {
            return dbContext.Users.ToList();
        }

        public User Get(int id)
        {
            return dbContext.Users.FirstOrDefault(e => e.ID_User == id);
        }

        public bool Post(User user)
        {
            List<User> dbUser = dbContext.Users.ToList();
            foreach(User item in dbUser) {
                if (item.Username == user.Username) {
                    return false;
                }
            }
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return true;
        }

        public User Put(int id, User user)
        {
            var entity = dbContext.Users.FirstOrDefault(e => e.ID_User == id);
            if (user.Email!=null) entity.Email = user.Email;
            if (user.Username!=null) entity.Username = user.Username;
            if (user.Name!=null) entity.Name = user.Name;
            dbContext.SaveChanges();
            return entity;
        }
        public bool Delete(int id)
        {
            var user = dbContext.Users.Find(id);
            if (user == null)
            {
                return false;
            }

            dbContext.Remove(user);
            dbContext.SaveChanges();

            return true;
        }

        public bool Banuser(int id) 
        {
            var user = dbContext.Users.FirstOrDefault(e => e.ID_User == id);
            if (user == null) {
                return false;
            }
            else {

                if (user.Ban == false) {
                    user.Ban = true;
                    dbContext.SaveChanges();
                }

                if (user.Ban == true) {
                    user.Ban = false;
                    dbContext.SaveChanges();
                }
            }
            return true;
        }

        public User Login(User user)
        {
            return dbContext.Users.FirstOrDefault(e => e.Username == user.Username && e.Password == user.Password);
        }

    }
}