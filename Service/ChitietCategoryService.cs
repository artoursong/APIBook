using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using bookAPI.Models;
using System.Linq;
using System.Collections.Generic;
using System;

namespace bookAPI.Service
{
    public class ChitietCategoryService
    {
        public WebBookContext dbContext {get; set;}
        public ChitietCategoryService() 
        {
            dbContext = new WebBookContext();
        }

        public IEnumerable<ChitietCategory> Get()
        {
            return dbContext.ChitietCategories.ToList();
        }


        public List<Category> GetByBookId(int idbook) 
        {
            List<Category> categories = new List<Category>();
            List<ChitietCategory> chitietCategories = dbContext.ChitietCategories.ToList();
            foreach (ChitietCategory item in chitietCategories) {
                if (item.ID_Book == idbook) {
                    Category category = dbContext.Categories.FirstOrDefault(e => e.ID_Category == item.ID_Category);
                    categories.Add(category);
                }
            }
            return categories;
        }
        public bool Post(ChitietCategory chitietCategory)
        {
            dbContext.ChitietCategories.Add(chitietCategory);
            dbContext.SaveChanges();
            return true;
        }

    }
}