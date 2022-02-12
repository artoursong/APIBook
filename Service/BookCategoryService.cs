using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using bookAPI.Models;
using System.Linq;
using System.Collections.Generic;

namespace bookAPI.Service
{
    public class BookCategoryService
    {
        public WebBookContext dbContext {get; set;}
        public BookCategoryService() 
        {
            dbContext = new WebBookContext();
        }

        public IEnumerable<Category> Get()
        {
            return dbContext.Categories.ToList();
        }

        public Category Get(int id)
        {
            return dbContext.Categories.FirstOrDefault(e => e.ID_Category == id);
        }

        public bool Post(Category category)
        {
            List<Category> dbCategory = dbContext.Categories.ToList();
            foreach(Category item in dbCategory) {
                if (item.Name == category.Name) {
                    return false;
                }
            }
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var category = dbContext.Categories.Find(id);
            if (category == null)
            {
                return false;
            }

            dbContext.Remove(category);
            dbContext.SaveChanges();

            return true;
        }
    }
}