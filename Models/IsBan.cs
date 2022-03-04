using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookAPI.Models
{
    public class IsBan
    {
        [Key]
        public int ID_IsBan {get; set;}
        public string Text {get; set;}
        public int? ID_User {get; set;}
        public int ID_Comment {get; set;}

        [ForeignKey("ID_User")]
        public virtual User user {get; set;}

        [ForeignKey("ID_Comment")]
        public virtual Comment comment {get; set;}

    }
}