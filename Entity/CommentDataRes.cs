using System;


namespace bookAPI.Models
{
    public class CommentDataRes
    {
        public int ID_Comment{get; set;}
        public string Name {get; set;}
        public int? ID_User{get; set;}
        public string Text {get; set;}
        public DateTime Create_Date {get;set;}
        
    }
}