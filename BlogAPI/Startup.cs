using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using BlogAPI.Models;
using Blog.Web.Models;

namespace BlogAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
            cfg.CreateMap<Post, PostDTO>().ForMember(p => p.PostingUserID, opt => opt.MapFrom(po => po.PostingUser.UserInfoID)).ReverseMap().ForPath(p => p.Comments, opt => opt.Ignore());
            cfg.CreateMap<Comment, CommentDTO>().ForMember(c => c.Post, opt => opt.MapFrom(src => src.Post)).ForMember(c => c.CommentingUser, opt => opt.MapFrom(src => src.CommentingUser)).ReverseMap().ForPath(s => s.CommentingUser, opt => opt.MapFrom(src => src.CommentingUser));
            cfg.CreateMap<UserInfo, UserinfoDTO>().ReverseMap().ForPath(u => u.Comments, opt => opt.Ignore()).ForPath(u => u.Posts, opt => opt.Ignore());
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<BlogAPIContext>(options =>
                    options.UseSqlServer(@"Server=(localdb)\\mssqllocaldb;Database=BlogAPIContext-f6e6f265-4faa-4f87-a186-9e4d1081e23f;Trusted_Connection=True;MultipleActiveResultSets=true"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseHttpsRedirection();
            app.UseMvc(routers =>
                {
                    routers.MapRoute("default", "{Controller=Posts}/{id?}/{action=Comment}");
                }
            );
            app.UseMvcWithDefaultRoute();
        }
    }
}
