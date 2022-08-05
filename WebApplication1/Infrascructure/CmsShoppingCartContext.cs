using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Infrascructure
{
    public class CmsShoppingCartContext : IdentityDbContext<AppUser>
    {
        public CmsShoppingCartContext(DbContextOptions<CmsShoppingCartContext> options) 
            : base(options)
        { 
        }

        public DbSet<Page> Pages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
