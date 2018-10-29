using BlogAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BlogAPI.Models.BlogAPIContext>
    {
        public BlogAPIContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<BlogAPIContext>();
            var connectionString = configuration.GetConnectionString("BlogAPIContext");
            builder.UseSqlServer(connectionString);
            return new BlogAPIContext(builder.Options);
        }
    }
}
