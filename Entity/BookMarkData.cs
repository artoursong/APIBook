using System;
using System.Collections.Generic;


namespace bookAPI.Models
{
    public class BookMarkData
    {
        public string Name {get; set;}
        public int ID_Book {get;set;}
        public string Image {get; set;}
        public List<ChapterDataResponse> listchap {get; set;}
        
    }
}