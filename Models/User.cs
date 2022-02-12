using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookAPI.Models
{
    public class User
    {
        [Key]
        public int ID_User {get; set;}
        public string Name {get; set;}
        public string Username{get; set;}
        public string Password {get; set; }
        public string Email {get; set;}
        public bool Role {get; set;}
        public bool Ban {get; set;}
        public int Coin {get; set;}
    }
}