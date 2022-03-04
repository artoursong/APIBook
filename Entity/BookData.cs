using System;


namespace bookAPI.Models
{
    public class BookData
    {
        public string Name {get; set;}
        public string Mo_ta{get; set;}
        public string Author {get; set;}
        public string Ten_khac {get; set;}
        public string Hoa_si {get; set;}
        public string Image {get; set;}
        public int ID_User {get; set;}
        public DateTime Create_date {get; set;}
        public string[] Categories {get; set;}
        
    }
}