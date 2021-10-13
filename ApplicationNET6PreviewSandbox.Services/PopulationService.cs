using ApplicationNET6PreviewSandbox.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNET6PreviewSandbox.Services
{
    public class PopulationService : IPopulationService
    {
        private readonly CountryDbContext _db;

        public PopulationService(CountryDbContext db)
        {
            _db = db;
        }

        public async Task<Country> Maximum()
        {
            var countries = await _db.Countries.Where(x => x.Population > 0).ToListAsync();

            return countries.MaxBy(x => x.Population)!;
        }

        public async Task<Country> Minimum()
        {
            var countries = await _db.Countries.Where(x => x.Population > 0).ToListAsync();

            return countries.MinBy(x => x.Population)!;
        }
    }
}
