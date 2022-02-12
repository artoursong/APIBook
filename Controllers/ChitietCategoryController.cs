using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookAPI.Models;
using bookAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace Namespace
{
    [Route("[controller]")]
    [ApiController]
    public class ChitietCategoryController : ControllerBase
    {
        public readonly ChitietCategoryService chitietCategoryService;

        public ChitietCategoryController() 
        {
            chitietCategoryService = new ChitietCategoryService();
        }
        [HttpGet]
        public IEnumerable<ChitietCategory> Get()
        {
            return chitietCategoryService.Get();
        }

        [HttpGet("{id}")]
        public List<Category> Get(int id) 
        {
            return chitietCategoryService.GetByBookId(id);
        }

    }
}