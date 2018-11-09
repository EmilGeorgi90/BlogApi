using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Blog.web.Models;

namespace Blog.web.Models
{
    public class BlogwebContext : DbContext
    {
        public BlogwebContext (DbContextOptions<BlogwebContext> options)
            : base(options)
        {
        }

        public DbSet<Blog.web.Models.UserInfo> UserInfo { get; set; }

        public DbSet<Blog.web.Models.Post> Post { get; set; }

        public DbSet<Blog.web.Models.Comment> Comment { get; set; }
    }
}
