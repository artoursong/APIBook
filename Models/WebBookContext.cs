using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookAPI.Models;

#nullable disable

namespace bookAPI.Models
{
    public partial class WebBookContext : DbContext
    {
        public WebBookContext()
        {
        }

        public WebBookContext(DbContextOptions<WebBookContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-RVJ2OET;Database=WebBook;Trusted_Connection=True");
            }
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Book> Books {get; set;}
        public virtual DbSet<Bookmark> Bookmakrs {get; set;}
        public virtual DbSet<Category> Categories {get; set;}
        public virtual DbSet<Chapter> Chapters {get; set;}
        public virtual DbSet<Comment> Comments {get; set;}
        public virtual DbSet<Follow> Follows {get; set;}
        public virtual DbSet<Rating> Ratings {get; set;}
        public virtual DbSet<ChitietCategory> ChitietCategories {get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
            modelBuilder.Entity<User>(entity => {
                entity.HasIndex(e => e.Username).IsUnique();
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
