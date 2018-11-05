﻿// <auto-generated />
using System;
using BlogAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlogAPI.Migrations
{
    [DbContext(typeof(BlogAPIContext))]
    [Migration("20181101080238_BlogApi")]
    partial class BlogApi
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlogAPI.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CommentingUserUserInfoID");

                    b.Property<string>("Content");

                    b.Property<DateTime>("DateOfComment");

                    b.Property<int?>("PostId");

                    b.HasKey("CommentId");

                    b.HasIndex("CommentingUserUserInfoID");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("BlogAPI.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<DateTime>("DateOfPost");

                    b.Property<string>("ImageUrl");

                    b.Property<int?>("PostingUserUserInfoID");

                    b.Property<string>("Title");

                    b.HasKey("PostId");

                    b.HasIndex("PostingUserUserInfoID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("BlogAPI.Models.UserInfo", b =>
                {
                    b.Property<int>("UserInfoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("NumberOfComments");

                    b.Property<int>("NumberOfPosts");

                    b.Property<string>("ProfilPictureUrl");

                    b.Property<DateTime>("RegisterDate");

                    b.Property<string>("Username");

                    b.HasKey("UserInfoID");

                    b.ToTable("UserInfos");
                });

            modelBuilder.Entity("BlogAPI.Models.Comment", b =>
                {
                    b.HasOne("BlogAPI.Models.UserInfo", "CommentingUser")
                        .WithMany("Comments")
                        .HasForeignKey("CommentingUserUserInfoID");

                    b.HasOne("BlogAPI.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("BlogAPI.Models.Post", b =>
                {
                    b.HasOne("BlogAPI.Models.UserInfo", "PostingUser")
                        .WithMany("Posts")
                        .HasForeignKey("PostingUserUserInfoID");
                });
#pragma warning restore 612, 618
        }
    }
}