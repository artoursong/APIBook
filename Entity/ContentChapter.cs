using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookAPI.Models
{
    public class ContentChapter
    {
        public int id {get; set;}
        public string content {get; set;}
    }
}