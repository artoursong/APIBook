using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using bookAPI.Models;
using System.Linq;
using System.Collections.Generic;
using System;


namespace bookAPI.Service
{
    public class BookService
    {
        public WebBookContext dbContext {get; set;}
        public BookService() 
        {
            dbContext = new WebBookContext();
        }

        public IEnumerable<Book> Get()
        {
            return dbContext.Books.ToList();
        }

        public Book Get(int id)
        {
            return dbContext.Books.FirstOrDefault(e => e.ID_Book == id);
        }

        public bool Post(BookData bookdata)
        {
            User user = dbContext.Users.FirstOrDefault(e => e.ID_User == bookdata.ID_User);
            Book book = new Book
            {
                userid = user,
                Name = bookdata.Name,
                Mo_ta = bookdata.Mo_ta,
                Author = bookdata.Author,
                Ten_khac = bookdata.Ten_khac,
                Hoa_si = bookdata.Hoa_si,
                Image = bookdata.Image,
                Create_date = System.DateTime.Now,
            };
            dbContext.Books.Add(book);
            dbContext.SaveChanges();

            foreach (string item in bookdata.Categories) 
            {
                ChitietCategory chitietCategory = new ChitietCategory
                {
                    book = book,
                    category = dbContext.Categories.FirstOrDefault(e => e.ID_Category == Convert.ToInt32(item))
                };
                dbContext.ChitietCategories.Add(chitietCategory);
                dbContext.SaveChanges();
            }
            return true;
        }

        public Book Put(int id, Book book)
        {
            var entity = dbContext.Books.FirstOrDefault(e => e.ID_Book == id);
            entity.Name = book.Name;
            entity.Mo_ta = book.Mo_ta;
            entity.Image = book.Image;
            entity.Rate_average = book.Rate_average;
            entity.View_sum = book.View_sum;
            entity.Author = book.Author;
            entity.Ten_khac = book.Ten_khac;
            entity.Hoa_si = book.Hoa_si;
            dbContext.SaveChanges();
            return entity;
        }
        public bool Delete(int id)
        {
            var book = dbContext.Books.Find(id);
            if (book == null)
            {
                return false;
            }

            dbContext.Remove(book);
            dbContext.SaveChanges();

            return true;
        }

        public string GetUserByBookId(int id) 
        {
            int iduser = dbContext.Books.Find(id).ID_User;
            return dbContext.Users.Find(iduser).Username;
        }


        public List<Book> GetBookByAuthor(string Author) 
        {
            List<Book> books = dbContext.Books.Where(e => e.Author == Author).ToList();
            return books;
        }
    }
}