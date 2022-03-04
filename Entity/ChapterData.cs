using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookAPI.Models
{
    public class ChapterData
    {
        public string Name {get; set;}
        public System.DateTime Create_date {get; set;}
        public int View {get; set; }
        public int ID_Volume {get; set;}
        public string Volume_name {get; set;}
        public string Book_name {get; set;}
        public int ID_Chapter {get; set;}
        public int ID_NextChapter {get; set;}
        public int ID_PreChapter {get; set;}
        public string Text {get; set;}
        public List<ContentChapter> contentchapter {get; set;} 
    }
}