using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookAPI.Models
{
    public class VolumeData
    {
        public int id {get; set;}
        public string name {get; set;}
        public string image {get; set;}
        public List<ChapterDataResponse> listchapter {get; set;}
    }
}