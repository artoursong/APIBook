using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bookAPI.Service;
using bookAPI.Models;

namespace Namespace
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly BookCategoryService bookCategoryService;

        public CategoryController() 
        {
            bookCategoryService = new BookCategoryService();
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return bookCategoryService.Get();
        }

        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return bookCategoryService.Get(id);
        }

        [HttpPost]
        public bool Post(Category category)
        {
            return bookCategoryService.Post(category);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return bookCategoryService.Delete(id);
        }
    }
}