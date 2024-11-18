using Jcf.EasyShopFlow.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jcf.EasyShopFlow.Infra.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
        }
    }
}
