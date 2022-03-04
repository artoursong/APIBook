using System.Collections.Generic;


namespace bookAPI.Models
{
    public class BanData
    {
        public int ID_Ban {get; set;}
        public int? ID_User {get; set;}
        public string Username {get; set;}
        public string Comment_Text {get; set;}
    }
}