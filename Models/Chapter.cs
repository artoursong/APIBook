using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookAPI.Models
{
    public class Chapter
    {
        [Key]
        public int ID_Chapter {get; set;}
        public string Name {get; set;}
        public System.DateTime Create_date {get; set;}
        public int View {get; set; }
        public string Text {get; set;}
        [ForeignKey("ID_Book")]
        public virtual Book Book {get; set;}
    }
}