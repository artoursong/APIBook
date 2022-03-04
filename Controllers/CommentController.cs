using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bookAPI.Service;
using bookAPI.Models;

namespace Namespace
{
    [Route("[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        public readonly CommentService commentService;

        public CommentController() {
            commentService = new CommentService();
        }
        [HttpPost("commentofbook")]
        public CommentData GetAllCommentOfBook(CommentDataRecive comment)
        {
            return commentService.GetCommentofBook(comment);
        }


        [HttpPost]
        public CommentData Post(Comment comment)
        {
            return commentService.Post(comment);
        }

        [HttpDelete("{id}")]
        public CommentData Delete(int id)
        {
            return commentService.Delete(id);
        }
    }
}