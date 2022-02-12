using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookAPI.Models
{
    public class Bookmark
    {
        [Key]
        public int ID_Bookmark {get; set;}
        public int Position {get; set;}
        [ForeignKey("ID_User")]
        public virtual User User {get; set;}
        [ForeignKey("ID_Chapter")]
        public virtual Chapter Chapter {get; set;}
    }
}