using BlogAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Web.Models
{
    public class CommentDTO
    {
        public int CommentId { get; set; }
        public UserinfoDTO CommentingUser { get; set; }
        public PostDTO Post { get; set; }
        public string Content { get; set; }
        public DateTime DateOfComment { get; set; }
    }
}
