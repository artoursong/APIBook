using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using bookAPI.Models;
using System.Linq;
using System.Collections.Generic;
using System;


namespace bookAPI.Service
{
    public class VolumeService
    {
        public WebBookContext dbContext {get; set;}
        public VolumeService() 
        {
            dbContext = new WebBookContext();
        }

        public IEnumerable<Volume> Get()
        {
            return dbContext.Volumes.ToList();
        }

        public Book Get(int id)
        {
            return dbContext.Books.FirstOrDefault(e => e.ID_Book == id);
        }

        public VolumeData Post(Volume volume)
        {
            Volume volumedb = dbContext.Volumes.Find(volume.ID_Volume);
            if (volumedb != null) {
                volumedb.name = volume.name;
                volumedb.Image = volume.Image;
                dbContext.SaveChanges();
                VolumeData volumeData = new VolumeData {
                    id = volumedb.ID_Volume,
                    name = volumedb.name,
                    image = volumedb.Image,
                };
                List<Chapter> chapters = dbContext.Chapters.Where(e => e.ID_Volume == volumeData.id).ToList();
                volumeData.listchapter = new List<ChapterDataResponse>();
                foreach (Chapter chapteritem in chapters) {
                    ChapterDataResponse chapterData = new ChapterDataResponse {
                        id = chapteritem.ID_Chapter,
                        name = chapteritem.Name,
                    };
                    volumeData.listchapter.Add(chapterData);
                }
                return volumeData;
            }
            if (volume.Image == null || volume.Image == "") volume.Image = "https://res.cloudinary.com/dlbkvfo8l/image/upload/v1645844443/woocommerce-placeholder-600x600_z402mf.png";
            dbContext.Volumes.Add(volume);
            dbContext.SaveChanges();
            VolumeData volumeData1 = new VolumeData {
                id = volume.ID_Volume,
                name = volume.name,
                image = volume.Image,
            };
            
            return volumeData1;
        }

        public bool Delete(int id)
        {
            Volume volume = dbContext.Volumes.Find(id);
            if (volume == null)
            {
                return false;
            }
            List<Chapter> chapters = dbContext.Chapters.Where(e => e.ID_Volume == id).ToList();
            foreach(Chapter item in chapters) {
                dbContext.Remove(item);
            }
            dbContext.Remove(volume);
            dbContext.SaveChanges();
            return true;
        }

        public List<Volume> GetAllVolumeOfBook(int idbook) {
            return dbContext.Volumes.Where(e => e.ID_Book == idbook).ToList();
        }

        public Volume GetOneVolume(int id) {
            return dbContext.Volumes.Find(id);
        }
    }
}