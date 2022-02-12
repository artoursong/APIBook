using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace bookAPI.Models
{
    public class ResponseLogin
    {
        
        public string token { get; set; }
        public LoginData LoginData { get; set;}
    }
}