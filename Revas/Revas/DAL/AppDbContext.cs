using Microsoft.EntityFrameworkCore;
using Revas.Models;

namespace Revas.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) { }
       public DbSet<Portfolio> portfolios { get; set; }
    }
}
