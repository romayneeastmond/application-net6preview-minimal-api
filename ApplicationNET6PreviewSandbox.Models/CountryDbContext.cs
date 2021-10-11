using Microsoft.EntityFrameworkCore;

namespace ApplicationNET6PreviewSandbox.Models
{
    public class CountryDbContext : DbContext
    {
        public CountryDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Country> Countries { get; set; } = null!;
    }
}