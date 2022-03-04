using System;
using System.Collections.Generic;

namespace bookAPI.Models
{
    public class CommentData
    {
        public int page {get;set;}
        public List<CommentDataRes> comment {get; set;}
        public double page_sum {get;set;}
        
    }
}