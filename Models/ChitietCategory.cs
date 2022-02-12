using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookAPI.Models
{
    public class ChitietCategory
    {
        [Key]
        public int ID_Chitiet {get; set;}
        public int ID_Book {get; set;}
        public int ID_Category{get; set;}

        [ForeignKey("ID_Book")]
        public virtual Book book {get; set; }
        [ForeignKey("ID_Category")]
        public virtual Category category {get; set; }

    }
}