using Divisima.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Divisima.DAL.DbContexts
{
    public class MSSQLDbContext : DbContext
    {
        public MSSQLDbContext(DbContextOptions<MSSQLDbContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<Admin>().HasData(new Admin {ID = 1, Name = "Yelda", Surname = "Kuru", UserName = "yeldakuru", Password = "2f37aebca0a4a88dfaa42ea2d7c30a24", LastIpNo = "", LastDate = DateTime.Now});

            modelBuilder.Entity<Product>().HasOne(h => h.Category).WithMany(w => w.Products).OnDelete(DeleteBehavior.SetNull);
        }


        public DbSet<Admin> Admin { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<SiteInfo> SiteInfo { get; set; }
    }
}
