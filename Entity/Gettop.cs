using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookAPI.Models
{
    public class Gettop
    {
        public List<Top10BookData> Top10NoiBat {get; set;}
        public List<Top10BookData> Top10TheoDoi {get; set;}
        public List<Top10BookData> NewUpdate {get;set;}
        
    }
}