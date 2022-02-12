using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookAPI.Models
{
    public class Category
    {
        [Key]
        public int ID_Category {get; set;}
        public string Name {get; set;}
    }
}