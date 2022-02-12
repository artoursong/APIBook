using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookAPI.Models
{
    public class Book
    {
        [Key]
        public int ID_Book {get; set;}
        public string Name {get; set;}
        public string Mo_ta{get; set;}
        public int Rate_average {get; set; }
        public string Author {get; set;}
        public string Ten_khac {get; set;}
        public string Hoa_si {get; set;}
        public System.DateTime Create_date {get; set;}
        public int View_sum {get; set;}
        public string Image {get; set;}
        public int ID_User {get; set;}
        [ForeignKey("ID_User")]
        public virtual User userid {get; set;}
        public virtual ICollection<ChitietCategory> ChitietCategories {get; set;}
    }
}