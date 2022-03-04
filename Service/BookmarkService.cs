using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using bookAPI.Models;
using System.Linq;
using System.Collections.Generic;
using System;


namespace bookAPI.Service
{
    public class BookMarkService
    {
        public WebBookContext dbContext {get; set;}
        public BookMarkService() 
        {
            dbContext = new WebBookContext();
        }

        public List<int> Get(Bookmark bookmark)
        {
            List<int> PositionOfChap = new List<int>();
            List<Bookmark> bookmarks = dbContext.Bookmakrs.Where(e => e.ID_User == bookmark.ID_User).ToList();
            foreach(Bookmark item in bookmarks) {
                if (item.ID_Chapter == bookmark.ID_Chapter) PositionOfChap.Add(item.Position);
            }
            return PositionOfChap;
        }

        public List<int> Post(Bookmark bookmark)
        {
            List<int> PositionOfChap = new List<int>();
            List<Bookmark> bookmarks = dbContext.Bookmakrs.Where(e => e.ID_User == bookmark.ID_User).ToList();
            foreach(Bookmark item in bookmarks) {
                if (item.ID_Chapter == bookmark.ID_Chapter) PositionOfChap.Add(item.Position);
            }
            if(bookmark != null) {
                List<Bookmark> bookmarks2 = dbContext.Bookmakrs.Where(e  => e.ID_Chapter == bookmark.ID_Chapter).Where(e => e.ID_User == bookmark.ID_User).ToList();
                foreach(Bookmark item in bookmarks2) {
                    if(item.Position == bookmark.Position) return PositionOfChap;
                }
                dbContext.Bookmakrs.Add(bookmark);
                dbContext.SaveChanges();
                PositionOfChap.Add(bookmark.Position);
            }
            return PositionOfChap;
        }

        public bool Delete(Bookmark bookmark)
        {
            List<Bookmark> bookmarks = dbContext.Bookmakrs.Where(e  => e.ID_Chapter == bookmark.ID_Chapter).Where(e => e.ID_User == bookmark.ID_User).ToList();
            
            foreach(Bookmark item in bookmarks) {
                if (item.Position == bookmark.Position) {
                    dbContext.Remove(item);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            
            return false;
        }

        public List<BookMarkData> GetBookmarkBook(int id) {
            List<Bookmark> bookmarks = dbContext.Bookmakrs.Where(e => e.ID_User == id).ToList();
            List<Chapter> chapters = new List<Chapter>();
            foreach(Bookmark item in bookmarks) {
                Chapter chapter = dbContext.Chapters.Find(item.ID_Chapter);
                chapters.Add(chapter);
            }
            List<Volume> volumes = new List<Volume>();
            foreach(Chapter item in chapters) {
                int dem = 0;
                Volume volume = dbContext.Volumes.Find(item.ID_Volume);
                if (volumes.Count == 0) {
                    volumes.Add(volume);
                }
                foreach (Volume itemvol in volumes) {
                    if(item.ID_Volume == itemvol.ID_Volume) dem++;
                }
                if(dem < volumes.Count) volumes.Add(volume);
            }
            List<Book> books = new List<Book>();
            foreach(Volume item in volumes) {
                int dem = 0;
                Book book = dbContext.Books.Find(item.ID_Book);
                if (books.Count == 0) books.Add(book);
                foreach (Book itembook in books) {
                    if(item.ID_Book == itembook.ID_Book) dem++;
                }
                if(dem < books.Count) books.Add(book);
            }
            List<BookMarkData> data = new List<BookMarkData>();
            foreach(Book item in books) {
                BookMarkData bookMark = new BookMarkData{
                    ID_Book = item.ID_Book,
                    Name = item.Name,
                    Image = item.Image,
                    listchap = new List<ChapterDataResponse>(),
                };
                foreach(Chapter itemchap in chapters) {
                    List<Volume> volumes1 = dbContext.Volumes.Where(e => e.ID_Book == item.ID_Book).ToList();
                    int dem = 0;
                    foreach(Volume itemvol in volumes1) {
                        
                        if (bookMark.listchap.Count == 0) {
                            ChapterDataResponse chap = new ChapterDataResponse {
                                id = itemchap.ID_Chapter,
                                name = itemchap.Name,
                            };
                            bookMark.listchap.Add(chap);
                        }
                        if (itemchap.ID_Volume == itemvol.ID_Volume) {
                            dem++;
                        }
                    }
                    if (dem < bookMark.listchap.Count) {
                        ChapterDataResponse chap = new ChapterDataResponse {
                                id = itemchap.ID_Chapter,
                                name = itemchap.Name,
                                Create_date = itemchap.Create_date,
                            };
                            bookMark.listchap.Add(chap);
                    }
                }
                data.Add(bookMark);
            }
            return data;

        }
    }
}