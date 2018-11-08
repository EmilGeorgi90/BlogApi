using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.web.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public UserInfo CommentingUser { get; set; }
        public Post Post { get; set; }
        public string Content { get; set; }
        public DateTime DateOfComment { get; set; }
    }
}
