using Microsoft.EntityFrameworkCore;

namespace ApplicationNET6PreviewSandbox.Models
{
    public interface ICountryDbContext
    {
        DbSet<Country> Countries { get; set; }
    }
}
