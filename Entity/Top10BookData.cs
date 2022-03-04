using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookAPI.Models
{
    public class Top10BookData
    {
        public int ID_Book {get; set;}
        public string Name {get; set;}
        public string Image {get; set;}
        public List<Category> categories {get; set;}
        public bool Tinh_trang {get; set;}
        public int Follow_sum {get; set;}
        public string Mo_ta {get; set;}
        
    }
}