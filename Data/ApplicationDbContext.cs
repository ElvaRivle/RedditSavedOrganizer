using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RedditOrganizeSaved.Models;

namespace RedditOrganizeSaved.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly DbContextOptions _options;
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Post>? Posts { get; set; }

        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Post>().ToTable("Posts");

            modelBuilder.Entity<Post>().HasKey(p => p.Id);
            modelBuilder.Entity<Post>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Post>().HasOne<Category>(p => p.Category).WithMany(c => c.Posts);
        }
    }
}
