using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Models
{
    public class Comment : IUserPost
    {
        public int CommentId { get; set; }
        public UserInfo CommentingUser { get; set; }
        public Post Post { get; set; }
        public string Content { get; set; }
        public DateTime DateOfComment { get; set; }
    }
}
