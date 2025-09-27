using Demo_Product.EntityLayer.Concrete;                
using Demo_Product.EntityLayer.Concrete.AppUser;         
using EntityLayer;

using Microsoft.AspNetCore.Identity;                      
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Demo_Product.DataAccessLayer.Concrete
{
    
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {

        public Context(DbContextOptions<Context> options) : base(options) { }

       
        public Context() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
              
            }
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

           
        }

       
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<Customer> Customers { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Job> Jobs { get; set; } = default!;
    }
}
