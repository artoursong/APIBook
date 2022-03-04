using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookAPI.Models
{
    public class Volume
    {
        [Key]
        public int ID_Volume {get; set;}
        public int ID_Book {get; set;}
        public string Image {get; set;}
        public string name {get; set;}
        [ForeignKey("ID_Book")]
        public virtual Book Book {get; set;}
    }
}