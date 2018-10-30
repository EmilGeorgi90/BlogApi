using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Models
{
    public class Post : IUserPost , IEqualityComparer<Post>
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateOfPost { get; set; }
        public UserInfo PostingUser { get; set; }
        public ICollection<Comment> Comments { get; set; }


        public bool Equals(Post x, Post y)
        {
            return x.PostId == y.PostId;
        }

        public int GetHashCode(Post obj)
        {
            throw new NotImplementedException();
        }
    }
}
