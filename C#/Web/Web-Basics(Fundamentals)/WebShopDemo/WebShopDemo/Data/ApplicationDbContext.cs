using Microsoft.EntityFrameworkCore;
using WebShopDemo.Core.Models;
namespace WebShopDemo.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebShopDemo.Core.Models.ProductDto> ProductDto { get; set; }
    }
}