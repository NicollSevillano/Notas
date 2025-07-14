using Microsoft.EntityFrameworkCore;
using NotasAPI.Models;

namespace NotasAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Nota> Notes { get; set; }
    }
}
