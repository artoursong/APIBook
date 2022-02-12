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

        public Chapter Get(int id)
        {
            return dbContext.Chapters.FirstOrDefault(e => e.ID_Chapter == id);
        }

        public bool Post(Chapter chapter)
        {
            List<Chapter> dbChapter = dbContext.Chapters.ToList();
            foreach(Chapter item in dbChapter) {
                if (item.Name == chapter.Name) {
                    return false;
                }
            }
            dbContext.Chapters.Add(chapter);
            dbContext.SaveChanges();
            return true;
        }

        public List<string> ConvertContent(string[] content) 
        {
            List<string> noidung = new List<string>();
            int i = 1;
            foreach(string item in content) 
            {
                string[] t1 = item.Split(new string[] {"<p>"}, System.StringSplitOptions.None);
                string temp = t1[1];
                string[] t2 = temp.Split(new string[] {"</p>"}, System.StringSplitOptions.None);
                t2[0] = "<p id='" + i.ToString() + "'>" + t2[0] + "</p>";
                i++;
                noidung.Add(t2[0]);
            }
            return noidung;
        }
        public void Put(int id, Chapter chapter)
        {
            var entity = dbContext.Chapters.FirstOrDefault(e => e.ID_Chapter == id);
            entity.Name = chapter.Name;
            entity.Create_date = chapter.Create_date;
            entity.Text = chapter.Text;
            entity.View = chapter.View;
            dbContext.SaveChanges();
        }
        public bool Delete(int id)
        {
            var chapter = dbContext.Chapters.Find(id);
            if (chapter == null)
            {
                return false;
            }

            dbContext.Remove(chapter);
            dbContext.SaveChanges();

            return true;
        }
    }
}