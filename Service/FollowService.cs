using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using bookAPI.Models;
using System.Linq;
using System.Collections.Generic;
using System;


namespace bookAPI.Service
{
    public class FollowService
    {
        public WebBookContext dbContext {get; set;}
        public FollowService() 
        {
            dbContext = new WebBookContext();
        }

        public List<int> GetFollows(int iduser) {
            List<Follow> follows = dbContext.Follows.Where(e => e.ID_User == iduser).ToList();
            List<FollowBook> listbook = new List<FollowBook>();
            List<int> id = new List<int>();
            foreach(Follow item in follows) {
                Book book = dbContext.Books.Find(item.ID_Book);
                Volume volume = new Volume();
                Chapter chapter = new Chapter();
                if(dbContext.Volumes.Where(e => e.ID_Book == book.ID_Book).ToList().Count > 0) {
                    volume = dbContext.Volumes.Where(e => e.ID_Book == book.ID_Book).OrderByDescending(e => e.ID_Volume).ToList().Last();
                    chapter = dbContext.Chapters.Where(e => e.ID_Volume == volume.ID_Volume).OrderByDescending(e => e.ID_Chapter).ToList().Last();
                }

                
                FollowBook followBook = new FollowBook {
                    ID_Book = book.ID_Book,
                    Image = book.Image,
                    Name = book.Name,
                    newvolume = volume.name,
                    newchapter = chapter.Name,
                };
                
                listbook.Add(followBook);
            }
            foreach(FollowBook item in listbook) {
                id.Add(item.ID_Book);
            }
            return id;
        }

        public List<FollowBook> Get(int iduser) {
            List<Follow> follows = dbContext.Follows.Where(e => e.ID_User == iduser).ToList();
            List<FollowBook> listbook = new List<FollowBook>();
            foreach(Follow item in follows) {
                Book book = dbContext.Books.Find(item.ID_Book);
                Volume volume = new Volume();
                Chapter chapter = new Chapter();
                if(dbContext.Volumes.Where(e => e.ID_Book == book.ID_Book).ToList().Count > 0) {
                    volume = dbContext.Volumes.Where(e => e.ID_Book == book.ID_Book).OrderByDescending(e => e.ID_Volume).ToList().Last();
                    chapter = dbContext.Chapters.Where(e => e.ID_Volume == volume.ID_Volume).OrderByDescending(e => e.ID_Chapter).ToList().Last();
                }
                FollowBook followBook = new FollowBook {
                    ID_Book = book.ID_Book,
                    Image = book.Image,
                    Name = book.Name,
                    newvolume = volume.name,
                    newchapter = chapter.Name,
                };
                
                listbook.Add(followBook);
            }
            return listbook;
        }
        public bool Delete(int idfollow)
        {
            Follow follow = dbContext.Follows.Find(idfollow);
            if (follow == null)
            {
                return false;
            }

            dbContext.Remove(follow);
            dbContext.SaveChanges();
            return true;
        }

        public List<int> Post(Follow follow) {
            User user = dbContext.Users.Find(follow.ID_User);
            Book book = dbContext.Books.Find(follow.ID_Book);
            List<Follow> follow1 = dbContext.Follows.Where(e => e.ID_User == follow.ID_User).ToList();
            List<FollowBook> listfollow = new List<FollowBook>();
            List<int> ID = new List<int>();
            foreach(Follow item in follow1) {
                if (item.ID_Book == book.ID_Book) {
                    dbContext.Remove(item);
                    book.Follow_sum --;
                    dbContext.SaveChanges();
                    ID = GetFollows(user.ID_User);
                    return ID;
                }
            }
            if (user != null && book != null) {
                book.Follow_sum ++;
                dbContext.Follows.Add(follow);
                dbContext.SaveChanges();
                ID = GetFollows(user.ID_User);
                return ID;
            }
            return ID;
        }

    }
}