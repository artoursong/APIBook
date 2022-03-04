using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using bookAPI.Models;
using System.Linq;
using System.Collections.Generic;
using System;


namespace bookAPI.Service
{
    public class CommentService
    {
        public WebBookContext dbContext {get; set;}
        public CommentService() 
        {
            dbContext = new WebBookContext();
        }

        public CommentData GetCommentofBook(CommentDataRecive comment) {

            List<Comment> comments = dbContext.Comments.Where(e => e.ID_Book == comment.ID_Book).OrderByDescending(e => e.ID_Comment).ToList();
            Comment[] arraycomment = comments.ToArray();
            double h = ((double)comments.Count)/10;
            CommentData commentData = new CommentData {
                page = comment.page,
                page_sum = Math.Ceiling(h),
            };
            commentData.comment = new List<CommentDataRes>();
            int count = comment.page - 1;
            
            for(int i = 0; i < 10; i++) {
                if (count * 10 + i > (comments.Count - 1)) break;
                User user = dbContext.Users.Find(arraycomment[count * 10 + i].ID_User);
                CommentDataRes commentDataRes = new CommentDataRes {
                    ID_Comment = arraycomment[count * 10 + i].ID_Comment,
                    Create_Date = arraycomment[count * 10 + i].Create_Date,
                    Name = user.Username,
                    ID_User = user.ID_User,
                    Text = arraycomment[count * 10 + i].Text,
                };
                commentData.comment.Add(commentDataRes);

            }
            return commentData;
        }

        public CommentData Delete(int idcomment)
        {
            Comment comment = dbContext.Comments.Find(idcomment);
            CommentDataRecive commentDataRecive = new CommentDataRecive {
                ID_Book = comment.ID_Book,
                page = 1,
            };
            if (comment == null)
            {
                return GetCommentofBook(commentDataRecive);
            }
            dbContext.Remove(comment);
            dbContext.SaveChanges();
            return GetCommentofBook(commentDataRecive);
        }

        public CommentData Post(Comment comment) {
            CommentDataRecive commentDataRecive = new CommentDataRecive {
                ID_Book = comment.ID_Book,
                page = 1,
            };
            if (comment.Text != null) {
                comment.Create_Date = DateTime.Now;
                dbContext.Comments.Add(comment);
                dbContext.SaveChanges();
                return GetCommentofBook(commentDataRecive);
            }
            return GetCommentofBook(commentDataRecive);
        }

        public List<Comment> Put(Comment comment) {
            Comment comment1 = dbContext.Comments.Find(comment.ID_Comment);
            if (comment1 != null) {
                comment1.Text = comment.Text;
                dbContext.SaveChanges();
                return dbContext.Comments.Where(e => e.ID_Book == comment.ID_Book).ToList();
            }
            return dbContext.Comments.Where(e => e.ID_Book == comment.ID_Book).ToList();
        }
    }
}