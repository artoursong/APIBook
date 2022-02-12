using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace bookAPI.Models
{
    public class LoginData
    {
    
        public int ID_User {get; set;}
        public string username {get; set;}
        public string name {get; set;}
        public string email {get; set;}
        public bool role {get; set;}
        public bool ban {get; set;}
        public int coin {get; set;}
    }
}