using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bookAPI.Models;
using bookAPI.Service;

namespace Namespace
{
    [Route("[controller]")]
    [ApiController]
    public class BookmarkController : ControllerBase
    {

        public readonly BookMarkService bookmarkService;

        public BookmarkController() 
        {
            bookmarkService = new BookMarkService();
        }
        [HttpPost("getbookmark")]
        public List<int> Get(Bookmark bookmark)
        {
            return bookmarkService.Get(bookmark);
        }

        [HttpPost]
        public List<int> Post(Bookmark bookmark)
        {
            return bookmarkService.Post(bookmark);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpPost("deletebookmark")]
        public bool Delete(Bookmark bookmark)
        {
            return bookmarkService.Delete(bookmark);
        }

        [HttpGet("{id}")]
        public List<BookMarkData> Get(int id)
        {
            return bookmarkService.GetBookmarkBook(id);
        }
    }
}