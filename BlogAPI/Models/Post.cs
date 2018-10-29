using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Models
{
    public class Post : IUserPost
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateOfPost { get; set; }
        public UserInfo PostingUser { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
