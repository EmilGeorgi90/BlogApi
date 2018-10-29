using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BlogAPI.Models
{
    public class UserInfo : IUserPost
    {
        private string profilePictureUrl;
        public int UserInfoID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string ProfilPictureUrl
        {
            get
            {
                return profilePictureUrl;
            }
            set
            {
                profilePictureUrl = value;
            }
        }
        public int NumberOfPosts { get; set; }
        public int NumberOfComments { get; set; }
        public DateTime RegisterDate { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments{ get; set; }
    }
}
