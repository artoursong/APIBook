using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using bookAPI.Models;
using System.Linq;
using System.Collections.Generic;

namespace bookAPI.Service
{
    public class ChapterService
    {
        public WebBookContext dbContext {get; set;}
        public ChapterService() 
        {
            dbContext = new WebBookContext();
        }

        public IEnumerable<Chapter> Get()
        {
            return dbContext.Chapters.ToList();
        }

        public ChapterData Get(int idchapter)
        {
            ChapterData chapterdata = new ChapterData {
                ID_Chapter = idchapter,
                Name = dbContext.Chapters.Find(idchapter).Name,
                contentchapter = new List<ContentChapter>(),
            };
            
            int idvolume = (dbContext.Chapters.Find(idchapter)).ID_Volume;
            chapterdata.Volume_name = (dbContext.Volumes.Find(idvolume)).name;
            int idbook = (dbContext.Volumes.Find(idvolume)).ID_Book;
            chapterdata.Book_name = (dbContext.Books.Find(idbook)).Name;
            Book book = dbContext.Books.Find(idbook);
            book.View_sum ++;
            dbContext.SaveChanges();
            List<Chapter> allchapterofvolume = dbContext.Chapters.Where(e => e.ID_Volume == idvolume).ToList();

            foreach(Chapter item in allchapterofvolume) {
                if (item.ID_Chapter > idchapter) {
                    chapterdata.ID_NextChapter = item.ID_Chapter;
                    break;
                }
            }

            chapterdata.ID_PreChapter = 0;

            foreach (Chapter item in allchapterofvolume) {
                if (item.ID_Chapter >= idchapter ) {
                    break;
                }
                if (item.ID_Chapter > chapterdata.ID_PreChapter) chapterdata.ID_PreChapter = item.ID_Chapter;
            }

            Chapter chapter = dbContext.Chapters.Find(idchapter);
            int idcontent = 1;
            string[] t = chapter.Text.Split(new string[] {"<p>"}, System.StringSplitOptions.None);
            foreach(string item in t) {
                string[] t1 = item.Split(new string[] {"</p>"}, System.StringSplitOptions.None);
                ContentChapter contentChapter = new ContentChapter {
                    id = idcontent,
                    content = t1[0]
                };
                idcontent++;
                chapterdata.contentchapter.Add(contentChapter);
            }
            
            return chapterdata;

        }

        public List<VolumeData> Post(ChapterData chapterdata)
        {
            List<VolumeData> volumeData = new List<VolumeData>();
            List<Chapter> dbChapter = dbContext.Chapters.Where(e => e.ID_Volume == chapterdata.ID_Volume).ToList();
            foreach(Chapter item in dbChapter) {
                if (item.Name == chapterdata.Name) {
                    return volumeData;
                }
            }

            Chapter chapter = new Chapter {
                Name = chapterdata.Name,
                ID_Volume = chapterdata.ID_Volume,
                Create_date = System.DateTime.Now,
                Text = chapterdata.Text,
            };

            int idbook = dbContext.Volumes.FirstOrDefault(e => e.ID_Volume == chapterdata.ID_Volume).ID_Book;
            Book book = dbContext.Books.Find(idbook);
            book.Update_date = chapter.Create_date;

            dbContext.Chapters.Add(chapter);
            dbContext.SaveChanges();
            
            
            Volume volume = dbContext.Volumes.Find(chapterdata.ID_Volume);
            List<Volume> listvolumeofbook = dbContext.Volumes.Where(e => e.ID_Book == volume.ID_Book).ToList();
            foreach(Volume item in listvolumeofbook) {
                VolumeData volumeData1 = new VolumeData {
                    id = item.ID_Volume,
                    name = item.name,
                    image = item.Image,
                };
                List<Chapter> chapters = dbContext.Chapters.Where(e => e.ID_Volume == volumeData1.id).ToList();
                volumeData1.listchapter = new List<ChapterDataResponse>();
                foreach (Chapter chapteritem in chapters) {
                    ChapterDataResponse chapterData = new ChapterDataResponse {
                        id = chapteritem.ID_Chapter,
                        name = chapteritem.Name,
                    };
                    volumeData1.listchapter.Add(chapterData);
                }
                volumeData.Add(volumeData1);

            }
            
            return volumeData;
        }

        public VolumeData Delete(int id)
        {
            Chapter chapter = dbContext.Chapters.Find(id);
            VolumeData volumeData1 = new VolumeData();
            if (chapter == null)
            {
                return volumeData1;
            }

            dbContext.Remove(chapter);
            dbContext.SaveChanges();

            
            Volume volume = dbContext.Volumes.Find(chapter.ID_Volume);
            VolumeData volumeData = new VolumeData{
                id = volume.ID_Volume,
                image = volume.Image,
                name = volume.name,
                
            };
            volumeData.listchapter = new List<ChapterDataResponse>();
            List<Chapter> chapters = dbContext.Chapters.Where(e => e.ID_Volume == chapter.ID_Volume).ToList();
            foreach(Chapter item in chapters) {
                ChapterDataResponse chapterDataResponse = new ChapterDataResponse {
                    id = item.ID_Chapter,
                    name = item.Name,
                    Create_date = item.Create_date,
                };
                volumeData.listchapter.Add(chapterDataResponse);
            }
            return volumeData;
        }

        public List<Chapter> GetAllChapterOfVolume(int idvolume) {
            return dbContext.Chapters.Where(e => e.ID_Volume == idvolume).ToList();
        }

        public bool Put(ChapterData chapterData) 
        {
            Chapter chapter = dbContext.Chapters.Find(chapterData.ID_Chapter);
            if (chapter == null) {
                return false;
            }
            if (chapterData.Name != null) chapter.Name = chapterData.Name;
            if (chapterData.Text != null) chapter.Text = chapterData.Text;
            dbContext.SaveChanges();
            return true;
        }
     }
}