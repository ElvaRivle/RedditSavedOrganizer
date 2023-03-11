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

        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().ToTable("Categories");
        }
    }
}
