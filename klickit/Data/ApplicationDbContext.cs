using klickit.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace klickit.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Product> (entity =>
        //    {
        //        entity.HasKey(e => e.Id);
        //        entity.Property(e => e.Status)
        //          .HasConversion<int> (); 
        //    });

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
