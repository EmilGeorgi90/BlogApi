using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BlogAPI.Models
{
    public class BlogAPIContext : DbContext
    {
        public BlogAPIContext(DbContextOptions<BlogAPIContext> options)
            : base(options)
        {
        }

        public DbSet<BlogAPI.Models.Comment> Comments { get; set; }
        public DbSet<BlogAPI.Models.Post> Posts { get; set; }
        public DbSet<BlogAPI.Models.UserInfo> UserInfos { get; set; }
        public ICollection<IUserPost> UserPosts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("BlogAPIContext"));
        }
    }
}
