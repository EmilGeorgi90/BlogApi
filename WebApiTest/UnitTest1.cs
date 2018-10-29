using BlogAPI.Controllers;
using BlogAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using Xunit;

namespace WebApiTest
{
    public class UnitTest1
    {

        [Fact]
        public void CheckAddCorrectly()
        {
            ICollection<IUserPost> sut = GetAllUserPost();
            UserInfo person = new UserInfo()
            {
                Username = "eg2711",
                Name = "emil georgi",
                NumberOfComments = 1234,
                NumberOfPosts = 10,
                ProfilPictureUrl = "https://i.imgur.com/ciVNs.gif",
                RegisterDate = DateTime.Now,
            };

            IUserPost savedPerson = AddIUserPost(person);

            Assert.Equal(person,savedPerson);
        }
        [Fact]
        public void IfRightAPICallFoundThenReturnOK()
        {
            var okResult = new PostsController((BlogAPIContext)GetDbContext()).GetPost(1);
            Assert.IsType<OkObjectResult>(okResult);
        }
        private ICollection<IUserPost> GetAllUserPost()
        {
            BlogAPIContext blogAPIContext = (BlogAPIContext)GetDbContext();
            blogAPIContext.UserPosts = new List<IUserPost>();
            foreach (IUserPost item in blogAPIContext.Comments)
            {
                blogAPIContext.UserPosts.Add(item);
            }
            foreach (IUserPost item in blogAPIContext.UserInfos)
            {
                blogAPIContext.UserPosts.Add(item);
            }
            foreach (IUserPost item in blogAPIContext.Posts)
            {
                blogAPIContext.UserPosts.Add(item);
            }
            return blogAPIContext.UserPosts;
        }
        private IUserPost AddIUserPost(IUserPost userPost)
        {
            var entry = GetDbContext().Add(userPost);
            return entry.Entity;
        }
        private DbContext GetDbContext()
        {
            DbContextOptions<BlogAPIContext> options;
            var builder = new DbContextOptionsBuilder<BlogAPIContext>();
            builder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=BlogAPIContext-f6e6f265-4faa-4f87-a186-9e4d1081e23f;Integrated Security=True");
            options = builder.Options;
            BlogAPIContext BlogAPIContext = new BlogAPIContext(options);
            return BlogAPIContext;
        }
    }
}
