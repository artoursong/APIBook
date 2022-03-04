using System;


namespace bookAPI.Models
{
    public class ChangePass
    {
        public string NewPass {get; set;} 
        public string OldPass {get; set;}
        public int ID_User {get; set;}
        
    }
}