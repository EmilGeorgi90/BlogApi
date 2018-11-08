using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Blog.web.Models
{
    public class BlogwebContext : DbContext
    {
        public BlogwebContext (DbContextOptions<BlogwebContext> options)
            : base(options)
        {
        }

        public DbSet<Blog.web.Models.UserInfo> UserInfo { get; set; }
    }
}
