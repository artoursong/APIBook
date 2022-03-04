using System;
using System.Collections.Generic;

namespace bookAPI.Models
{
    public class AllBookPage
    {
        public int page {get;set;}
        public List<BookFind> book {get; set;}
        public double page_sum {get;set;}
        
    }
}