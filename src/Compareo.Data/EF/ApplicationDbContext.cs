using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Compareo.Data.Entities;

namespace Compareo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        
        public DbSet<Category> Category { get; set; }
        
        public DbSet<SubCategory> SubCategory { get; set; }
        
        public DbSet<Comment> Comment { get; set; }
        
        public DbSet<Product> Product { get; set; }
        
        public DbSet<Rate> Rate { get; set; }
        
        public DbSet<Shop> Shop { get; set; }
        
        public DbSet<Report> Report { get; set; }
    }
}