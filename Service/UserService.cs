using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using bookAPI.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Net.Mail;
using System;

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
            if (user.Role!=false) entity.Role = true;
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

        public bool NewPassChange(ChangePass changePass) {
            User user = dbContext.Users.Find(changePass.ID_User);
            if (changePass.NewPass.Length >= 6 && user.Password == changePass.OldPass && changePass.NewPass != "" && changePass.NewPass != null && changePass.NewPass != changePass.OldPass) {
                user.Password = changePass.NewPass;
                dbContext.SaveChanges();
                return true;
            }
            else return false;
            
            
        }

         public void Send_Mail(string SendFrom, string SendTo, string username) 
        {
            User user = dbContext.Users.FirstOrDefault(e => e.Username == username);
            try {
            MailMessage mail = new MailMessage(SendFrom, SendTo);
            mail.IsBodyHtml = true;
            mail.Subject = "MẬT KHẨU MỚI CỦA BẠN LÀ";
            Random r = new Random();
            string pass = r.Next(0,9).ToString() + r.Next(0,9).ToString() + r.Next(0,9).ToString() + r.Next(0,9).ToString()+ r.Next(0,9).ToString()+ r.Next(0,9).ToString();
            string Body = pass;
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential(SendFrom, "tinhanhem");
            smtp.Port = 587;
            smtp.EnableSsl = true;
            
            smtp.Send(mail);
            user.Password = pass;
            dbContext.SaveChanges();
            }
            catch(Exception e) {

            }
        }

        public bool passforgot(string username) {
            User user = new User();
            user = dbContext.Users.FirstOrDefault(e => e.Username == username);
            if (user == null) return false;
            Send_Mail("duy147862@gmail.com", user.Email, user.Username);
            return true;
        }

    }
}