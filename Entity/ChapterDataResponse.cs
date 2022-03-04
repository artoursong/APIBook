using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookAPI.Models
{
    public class ChapterDataResponse
    {
        public int id {get; set;}
        public string name {get; set;}
        public DateTime Create_date {get; set;}
        
    }
}