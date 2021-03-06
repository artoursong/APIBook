using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookAPI.Models
{
    public class Comment
    {
        [Key]
        public int ID_Comment {get; set;}
        public string Text {get; set;}
        public int ID_Book {get; set;}
        public int? ID_User {get; set;}
        public System.DateTime Create_Date {get; set;}

        [ForeignKey("ID_User")]
        public virtual User user {get; set;}
        [ForeignKey("ID_Book")]
        public virtual Book book {get; set;}

    }
}