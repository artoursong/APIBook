using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using bookAPI.Models;
using System.Linq;
using System.Collections.Generic;
using System;


namespace bookAPI.Service
{
    public class IsBanService
    {
        public WebBookContext dbContext {get; set;}
        public IsBanService() 
        {
            dbContext = new WebBookContext();
        }

        public bool Post(IsBan data) {
            dbContext.IsBans.Add(data);
            dbContext.SaveChanges();
            return true;
        }

        public List<BanData> BanUser(int id) {
            User user = dbContext.Users.Find(id);
            user.Ban = true;
            List<Comment> comments = dbContext.Comments.Where(e => e.ID_User == id).ToList();
            List<IsBan> isBans = dbContext.IsBans.Where(e => e.ID_User == id).ToList();
            foreach(IsBan item in isBans) {
                dbContext.IsBans.Remove(item);
            }
            foreach(Comment item in comments) {
                dbContext.Comments.Remove(item);
            }
            dbContext.SaveChanges();
            List<IsBan> banlist = dbContext.IsBans.ToList();
            List<BanData> bandata = new List<BanData>();
            foreach(IsBan item in banlist) {
                User itemuser = dbContext.Users.Find(item.ID_User);
                Comment itemcomment = dbContext.Comments.Find(item.ID_Comment);
                BanData data = new BanData {
                    ID_Ban = item.ID_IsBan,
                    ID_User = item.ID_User,
                    Username = itemuser.Username,
                    Comment_Text = itemcomment.Text,
                };
                bandata.Add(data);
            }
            return bandata;
        }

        public List<BanData> NotBan(int id) {
            IsBan isban = dbContext.IsBans.Find(id);
            dbContext.IsBans.Remove(isban);
            dbContext.SaveChanges();
            List<IsBan> banlist = dbContext.IsBans.ToList();
            List<BanData> bandata = new List<BanData>();
            foreach(IsBan item in banlist) {
                User itemuser = dbContext.Users.Find(item.ID_User);
                Comment itemcomment = dbContext.Comments.Find(item.ID_Comment);
                BanData data = new BanData {
                    ID_Ban = item.ID_IsBan,
                    ID_User = item.ID_User,
                    Username = itemuser.Username,
                    Comment_Text = itemcomment.Text,
                };
                bandata.Add(data);
            }
            return bandata;
        }

        public List<BanData> Banned() {
            List<User> users = dbContext.Users.Where(e => e.Ban == true).ToList();
            List<BanData> bandata = new List<BanData>();
            foreach(User item in users) {
                BanData data = new BanData {
                    ID_User = item.ID_User,
                    Username = item.Username,
                };
                bandata.Add(data);
            }
            return bandata;
        }

        public List<BanData> UnBan(int id) {
            User user = dbContext.Users.Find(id);
            user.Ban = false;
            dbContext.SaveChanges();
            List<User> users = dbContext.Users.Where(e => e.Ban == true).ToList();
            List<BanData> bandata = new List<BanData>();
            foreach(User item in users) {
                BanData data = new BanData {
                    ID_User = item.ID_User,
                    Username = item.Username,
                };
                bandata.Add(data);
            }
            return bandata;
        }
        public List<BanData> GetList() {
            List<IsBan> banlist = dbContext.IsBans.ToList();
            List<BanData> bandata = new List<BanData>();
            foreach(IsBan item in banlist) {
                User itemuser = dbContext.Users.Find(item.ID_User);
                Comment itemcomment = dbContext.Comments.Find(item.ID_Comment);
                BanData data = new BanData {
                    ID_Ban = item.ID_IsBan,
                    ID_User = item.ID_User,
                    Username = itemuser.Username,
                    Comment_Text = itemcomment.Text,
                };
                bandata.Add(data);
            }
            return bandata;
        }
    }
}