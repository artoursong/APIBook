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
    public class BookController : ControllerBase
    {
        public readonly BookService bookService;

        public BookController() 
        {
            bookService = new BookService();
        }
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return bookService.Get();
        }

        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return bookService.Get(id);
        }

        [HttpPost]
        public bool Post(BookData bookdata)
        {
            return bookService.Post(bookdata);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book book)
        {
            Book bookinfo = bookService.Put(id, book);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return bookService.Delete(id);
        }

        [HttpGet("getuser/{id}")]
        public string GetAuthor(int id) 
        {
            return bookService.GetUserByBookId(id);
        }

        [HttpGet("getbookbyauth/{auth}")]
        public List<Book> GetAuthor(string auth) 
        {
            return bookService.GetBookByAuthor(auth);
        }
    }
}