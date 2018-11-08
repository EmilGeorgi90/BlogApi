using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.web.Models
{
    public class UserInfo
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
    }
}
