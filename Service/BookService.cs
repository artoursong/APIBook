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

        public BookDataResponse Get(int id)
        {
            Book book = dbContext.Books.FirstOrDefault(e => e.ID_Book == id);
            ChitietCategoryService chitietCategoryService = new ChitietCategoryService();
            BookDataResponse bookData = new BookDataResponse {
                ID_User = book.ID_User,
                Name = book.Name,
                Mo_ta = book.Mo_ta,
                Image = book.Image,
                Hoa_si = book.Hoa_si,
                Author = book.Author,
                Create_date = book.Create_date,
                Ten_khac = book.Ten_khac,
                View_sum = book.View_sum,
                categories = chitietCategoryService.GetByBookId(id),
                volumes = new List<VolumeData>(),
                Update_date = book.Update_date,
                
            };
            List<Volume> volumes = dbContext.Volumes.Where(e => e.ID_Book == id).ToList();
            foreach (Volume item in volumes) {
                VolumeData volume = new VolumeData {
                    id = item.ID_Volume,
                    name = item.name,
                    image = item.Image,
                };
                bookData.volumes.Add(volume);
            }
            
            foreach (VolumeData item in bookData.volumes) {
                List<Chapter> chapters = dbContext.Chapters.Where(e => e.ID_Volume == item.id).ToList();
                item.listchapter = new List<ChapterDataResponse>();
                foreach (Chapter chapteritem in chapters) {
                    ChapterDataResponse chapterData = new ChapterDataResponse {
                        id = chapteritem.ID_Chapter,
                        name = chapteritem.Name,
                        Create_date = chapteritem.Create_date,
                    };
                    item.listchapter.Add(chapterData);
                }
            }

            bookData.Same_Category = Cungtheloai(bookData.categories);

            return bookData;
        }

        public List<BookDataResponse> Cungtheloai(List<Category> DataCate) {
            Category[] arraycate = DataCate.ToArray();
            List<BookDataResponse> data = new List<BookDataResponse>();
            ChitietCategoryService chitietCategoryService = new ChitietCategoryService();
            Category category = dbContext.Categories.FirstOrDefault(e => e.Name == arraycate[0].Name);
            List<ChitietCategory> chitietCategories = dbContext.ChitietCategories.Where(e => e.ID_Category == category.ID_Category).OrderByDescending(e => e.ID_Chitiet).Take(5).ToList();
            foreach(ChitietCategory item in chitietCategories) {
                Book book = dbContext.Books.Find(item.ID_Book);
                BookDataResponse bookdata = new BookDataResponse {
                    Name = book.Name,
                    categories = chitietCategoryService.GetByBookId(book.ID_Book),
                    Mo_ta = book.Mo_ta,
                    Image = book.Image
                };
                data.Add(bookdata);
            }
            return data;

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
                Tinh_trang = false,
                Follow_sum = 0,
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

        public void Put(int id, Book book)
        {
            Book entity = dbContext.Books.FirstOrDefault(e => e.ID_Book == id);
            if (entity != null) {
                if (book.Name != null) entity.Name = book.Name;
                if (book.Mo_ta != null) entity.Mo_ta = book.Mo_ta;
                if (book.Image != null) entity.Image = book.Image;
                if (book.Author != null) entity.Author = book.Author;
                if (book.Ten_khac != null) entity.Ten_khac = book.Ten_khac;
                if (book.Hoa_si != null) entity.Hoa_si = book.Hoa_si;
            }
            dbContext.SaveChanges();
        }
        public bool Delete(int id)
        {
            VolumeService volumeService = new VolumeService();
            var book = dbContext.Books.Find(id);
            if (book == null)
            {
                return false;
            }

            dbContext.Remove(book);
            dbContext.SaveChanges();

            List<Volume> volumes = dbContext.Volumes.Where(e => e.ID_Book == id).ToList();
            foreach(Volume item in volumes) {
                volumeService.Delete(item.ID_Volume);
            }
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

        public List<Top10BookData> GetTop10() 
        {
            List<Book> books = dbContext.Books.OrderByDescending(e => e.Follow_sum).Take(10).ToList();
            List<Top10BookData> top10 = new List<Top10BookData>();
            foreach (Book item in books) {
                Top10BookData bookdata = new Top10BookData {
                    ID_Book = item.ID_Book,
                    Name = item.Name,
                    Follow_sum = item.Follow_sum,
                    Image = item.Image,
                };
                top10.Add(bookdata);
            }

            return top10;
        }

        public List<Top10BookData> GetTop10NoiBat() 
        {
            List<Book> books = dbContext.Books.OrderByDescending(e => e.View_sum).Take(10).ToList();
            List<Top10BookData> top10 = new List<Top10BookData>();
            ChitietCategoryService chitietCategoryService = new ChitietCategoryService();
            foreach (Book item in books) {
                Top10BookData bookdata = new Top10BookData {
                    ID_Book = item.ID_Book,
                    Name = item.Name,
                    Follow_sum = item.Follow_sum,
                    Image = item.Image,
                    Tinh_trang = item.Tinh_trang,
                    categories = chitietCategoryService.GetByBookId(item.ID_Book),
                };
                top10.Add(bookdata);
            }
            
            return top10;
        }

        public List<BookOfUser> GetBookByIdUser(int id) {
            List<Book> books = dbContext.Books.Where(e => e.ID_User == id).ToList();
            List<BookOfUser> bookOfUsers = new List<BookOfUser>();
            foreach (Book item in books) {
                BookOfUser book = new BookOfUser {
                    ID_Book = item.ID_Book,
                    Name = item.Name,
                    Image = item.Image
                };
                bookOfUsers.Add(book);
            }
            return bookOfUsers;
        }

        public List<Top10BookData> GetNew() {
            List<Book> books = dbContext.Books.OrderByDescending(e => e.Update_date).Take(10).ToList();
            List<Top10BookData> top10 = new List<Top10BookData>();
             foreach (Book item in books) {
                Top10BookData bookdata = new Top10BookData {
                    ID_Book = item.ID_Book,
                    Name = item.Name,
                    Image = item.Image,
                    Mo_ta = item.Mo_ta
                };
                top10.Add(bookdata);
            }
            return top10;
            
        }

        public AllBookPage GetByAuthorOrCategory(BookDataRecive book) {
            Category category = dbContext.Categories.FirstOrDefault(e => e.Name == book.namedata);
            List<Book> books = new List<Book>();
            List<ChitietCategory> chitietCategories = dbContext.ChitietCategories.Where(e => e.ID_Category == category.ID_Category).ToList();
             foreach(ChitietCategory item in chitietCategories) {
                Book book1 = dbContext.Books.Find(item.ID_Book);
                books.Add(book1);
            }
            Book[] arraybook = books.ToArray();
            double h = ((double)books.Count)/10;
            AllBookPage all = new AllBookPage {
                page = book.page,
                page_sum = Math.Ceiling(h),
            };

            all.book = new List<BookFind>();
            int count = book.page - 1;

            for(int i = 0; i < 10; i++) {
                if (count * 10 + i > (books.Count - 1)) break;
                BookFind bookfind = new BookFind {
                    ID_Book = arraybook[count * 10 + i].ID_Book,
                    Image = arraybook[count * 10 + i].Image,
                    Name = arraybook[count * 10 + i].Name,
                };
                all.book.Add(bookfind);
            }
            return all;

        }

        public List<BookFind> FindBook(string data) {
            List<Book> books = dbContext.Books.ToList();
            List<BookFind> bookFinds = new List<BookFind>();
            foreach(Book item in books) {
                string newname = item.Name.ToLower();
                if (newname.IndexOf(data.ToLower()) != -1) {
                    BookFind bookFind = new BookFind {
                        ID_Book = item.ID_Book,
                        Image = item.Image,
                        Name = item.Name,
                    };
                    bookFinds.Add(bookFind);
                }
            }
            return bookFinds;
        }

        public AllBookPage AllBook(BookDataRecive bookData) {
            List<Book> books = dbContext.Books.ToList();
            Book[] arraybook = books.ToArray();
            double h = ((double)books.Count)/10;
            AllBookPage all = new AllBookPage {
                page = bookData.page,
                page_sum = Math.Ceiling(h),
            };

            all.book = new List<BookFind>();
            int count = bookData.page - 1;

            List<BookFind> bookss = new List<BookFind>();

            for(int i = 0; i < 10; i++) {
                if (count * 10 + i > (books.Count - 1)) break;
                BookFind book = new BookFind {
                    ID_Book = arraybook[count * 10 + i].ID_Book,
                    Image = arraybook[count * 10 + i].Image,
                    Name = arraybook[count * 10 + i].Name,
                    status = arraybook[count * 10 + i].Tinh_trang,
                };
                bookss.Add(book);
            }

            

            if (bookData.status != "") {
                foreach (BookFind item in bookss) {
                    if (item.status == bool.Parse(bookData.status)) {
                        all.book.Add(item);
                    }
                }
            }
            return all;

        }
        
    }
}