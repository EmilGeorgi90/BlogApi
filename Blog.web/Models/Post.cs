using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.web.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateOfPost { get; set; }
        public int PostingUserID { get; set; }
        public UserInfo PostingUser { get; set; }
    }
}
