using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookAPI.Models
{
    public class Comment
    {
        [Key]
        public int ID_Comment {get; set;}
        public string Text {get; set;}
        [ForeignKey("ID_User")]
        public virtual User User {get; set;}
        [ForeignKey("ID_Book")]
        public virtual Book Book {get; set;}
        [ForeignKey("ID_Comment")]
        public virtual Comment Comments {get; set;}

    }
}