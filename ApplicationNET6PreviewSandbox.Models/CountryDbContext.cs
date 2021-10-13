using Microsoft.EntityFrameworkCore;

namespace ApplicationNET6PreviewSandbox.Models
{
    public class CountryDbContext : DbContext, ICountryDbContext
    {
        public CountryDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Country> Countries { get; set; } = null!;
    }
}