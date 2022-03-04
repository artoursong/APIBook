using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using bookAPI.Models;
using System.Linq;
using System.Collections.Generic;
using System;


namespace bookAPI.Service
{
    public class RatingService
    {
        public WebBookContext dbContext {get; set;}
        public RatingService() 
        {
            dbContext = new WebBookContext();
        }

        public bool Post(Rating rating) {
            User user = dbContext.Users.Find(rating.ID_User);
            Book book = dbContext.Books.Find(rating.ID_Book);
            if (user != null && book != null) {
                dbContext.Ratings.Add(rating);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public int Rate_average(int idbook) {
            List<Rating> rate = dbContext.Ratings.Where(e => e.ID_Book == idbook).ToList();
            int rateaverage = 0;
            foreach(Rating item in rate) {
                rateaverage += item.Value;
            }
            rateaverage = rateaverage/rate.Count();
            return rateaverage;
        }
    }
}