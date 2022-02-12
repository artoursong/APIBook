﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bookAPI.Models;

namespace bookAPI.Migrations
{
    [DbContext(typeof(WebBookContext))]
    partial class WebBookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("bookAPI.Models.Book", b =>
                {
                    b.Property<int>("ID_Book")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Create_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Hoa_si")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ID_User")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mo_ta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rate_average")
                        .HasColumnType("int");

                    b.Property<string>("Ten_khac")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("View_sum")
                        .HasColumnType("int");

                    b.HasKey("ID_Book");

                    b.HasIndex("ID_User");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("bookAPI.Models.Bookmark", b =>
                {
                    b.Property<int>("ID_Bookmark")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ID_Chapter")
                        .HasColumnType("int");

                    b.Property<int?>("ID_User")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.HasKey("ID_Bookmark");

                    b.HasIndex("ID_Chapter");

                    b.HasIndex("ID_User");

                    b.ToTable("Bookmakrs");
                });

            modelBuilder.Entity("bookAPI.Models.Category", b =>
                {
                    b.Property<int>("ID_Category")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Category");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("bookAPI.Models.Chapter", b =>
                {
                    b.Property<int>("ID_Chapter")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Create_date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ID_Book")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("View")
                        .HasColumnType("int");

                    b.HasKey("ID_Chapter");

                    b.HasIndex("ID_Book");

                    b.ToTable("Chapters");
                });

            modelBuilder.Entity("bookAPI.Models.ChitietCategory", b =>
                {
                    b.Property<int>("ID_Chitiet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ID_Book")
                        .HasColumnType("int");

                    b.Property<int>("ID_Category")
                        .HasColumnType("int");

                    b.HasKey("ID_Chitiet");

                    b.HasIndex("ID_Book");

                    b.HasIndex("ID_Category");

                    b.ToTable("ChitietCategories");
                });

            modelBuilder.Entity("bookAPI.Models.Comment", b =>
                {
                    b.Property<int>("ID_Comment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ID_Book")
                        .HasColumnType("int");

                    b.Property<int?>("ID_User")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Comment");

                    b.HasIndex("ID_Book");

                    b.HasIndex("ID_User");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("bookAPI.Models.Follow", b =>
                {
                    b.Property<int>("ID_Follow")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ID_Book")
                        .HasColumnType("int");

                    b.Property<int?>("ID_User")
                        .HasColumnType("int");

                    b.HasKey("ID_Follow");

                    b.HasIndex("ID_Book");

                    b.HasIndex("ID_User");

                    b.ToTable("Follows");
                });

            modelBuilder.Entity("bookAPI.Models.Rating", b =>
                {
                    b.Property<int>("ID_Rating")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ID_Book")
                        .HasColumnType("int");

                    b.Property<int?>("ID_User")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("ID_Rating");

                    b.HasIndex("ID_Book");

                    b.HasIndex("ID_User");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("bookAPI.Models.User", b =>
                {
                    b.Property<int>("ID_User")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Ban")
                        .HasColumnType("bit");

                    b.Property<int>("Coin")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Role")
                        .HasColumnType("bit");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID_User");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("bookAPI.Models.Book", b =>
                {
                    b.HasOne("bookAPI.Models.User", "userid")
                        .WithMany()
                        .HasForeignKey("ID_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("userid");
                });

            modelBuilder.Entity("bookAPI.Models.Bookmark", b =>
                {
                    b.HasOne("bookAPI.Models.Chapter", "Chapter")
                        .WithMany()
                        .HasForeignKey("ID_Chapter");

                    b.HasOne("bookAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("ID_User");

                    b.Navigation("Chapter");

                    b.Navigation("User");
                });

            modelBuilder.Entity("bookAPI.Models.Chapter", b =>
                {
                    b.HasOne("bookAPI.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("ID_Book");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("bookAPI.Models.ChitietCategory", b =>
                {
                    b.HasOne("bookAPI.Models.Book", "book")
                        .WithMany("ChitietCategories")
                        .HasForeignKey("ID_Book")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bookAPI.Models.Category", "category")
                        .WithMany()
                        .HasForeignKey("ID_Category")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("book");

                    b.Navigation("category");
                });

            modelBuilder.Entity("bookAPI.Models.Comment", b =>
                {
                    b.HasOne("bookAPI.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("ID_Book");

                    b.HasOne("bookAPI.Models.Comment", "Comments")
                        .WithMany()
                        .HasForeignKey("ID_Comment")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("bookAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("ID_User");

                    b.Navigation("Book");

                    b.Navigation("Comments");

                    b.Navigation("User");
                });

            modelBuilder.Entity("bookAPI.Models.Follow", b =>
                {
                    b.HasOne("bookAPI.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("ID_Book");

                    b.HasOne("bookAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("ID_User");

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("bookAPI.Models.Rating", b =>
                {
                    b.HasOne("bookAPI.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("ID_Book");

                    b.HasOne("bookAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("ID_User");

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("bookAPI.Models.Book", b =>
                {
                    b.Navigation("ChitietCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
