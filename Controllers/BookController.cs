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
        public BookDataResponse Get(int id)
        {
            return bookService.Get(id);
        }

        [HttpPost]
        public bool Post(BookData bookdata)
        {
            return bookService.Post(bookdata);
        }

        [HttpPut("{id}")]
        public void Put(int id, Book book)
        {
            bookService.Put(id, book);
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

        [HttpGet("gettop10")]
        public Gettop gettop()
        {
            Gettop top = new Gettop {
                Top10NoiBat = bookService.GetTop10NoiBat(),
                Top10TheoDoi = bookService.GetTop10(),
                NewUpdate = bookService.GetNew()
            };
            return top;
        }

        [HttpGet("bookofuser/{id}")]
        public List<BookOfUser> GetBooksOfUser(int id) {
            return bookService.GetBookByIdUser(id);
        }

        [HttpPost("findby")]
        public AllBookPage GetByAuthOrCate(BookDataRecive data) {
            return bookService.GetByAuthorOrCategory(data);
        }
        [HttpGet("newbook")]
        public List<Top10BookData> getnew() {
            return bookService.GetNew();
        }

        [HttpGet("findbook/{data}")]
        public List<BookFind> SearchBook(string data) {
            return bookService.FindBook(data);
        }

        [HttpPost("allbookpage")]
        public AllBookPage getallbook(BookDataRecive data) {
            return bookService.AllBook(data);
        }
    }
}