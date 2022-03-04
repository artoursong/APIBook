using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookAPI.Models
{
    public class BookDataResponse
    {
        public string Name {get; set;}
        public string Mo_ta{get; set;}
        public string Author {get; set;}
        public string Ten_khac {get; set;}
        public string Hoa_si {get; set;}
        public string Image {get; set;}
        public int ID_User {get; set;}
        public int View_sum {get; set;}
        public DateTime Create_date {get; set;}
        public DateTime Update_date  {get; set;}
        public List<Category> categories{get; set;}
        public List<VolumeData> volumes {get; set;}

        public List<BookDataResponse> Same_Category {get; set;}
        
    }
}