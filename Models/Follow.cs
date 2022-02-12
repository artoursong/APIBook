using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookAPI.Models
{
    public class Follow
    {
        [Key]
        public int ID_Follow {get; set;}
        [ForeignKey("ID_User")]
        public virtual User User {get; set;}
        [ForeignKey("ID_Book")]
        public virtual Book Book {get; set;}
    }
}