using ApplicationNET6PreviewSandbox.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ApplicationNET6PreviewSandbox.Services
{
    public class CountryService
    {
        private CountryDbContext _db;

        public CountryService(CountryDbContext db)
        {
            _db = db;
        }

        public async Task<List<Country>> Get()
        {
            return await _db.Countries.ToListAsync();
        }

        public async Task<Country> Get(string code)
        {
            return await _db.Countries.FindAsync(code);
        }

        public async Task<IEnumerable<Country[]>> GetByRegion(string region)
        {
            var countries = await _db.Countries.Where(x => x.Region == region).ToListAsync();

            return countries.Chunk(10);
        }

        public async Task<Country> Insert(Country country)
        {
            _db.Countries.Add(country);

            await _db.SaveChangesAsync();

            return country;
        }

        public async Task Update(string code, Country country)
        {
            var countryItem = await _db.Countries.FindAsync(code);

            if (countryItem == null)
            {
                throw new KeyNotFoundException(code);
            }

            countryItem.Name = country.Name;
            countryItem.Continent = country.Continent;
            countryItem.Region = country.Region;
            countryItem.Population = country.Population;

            await _db.SaveChangesAsync();
        }

        public async Task Delete(string code)
        {
            var countryItem = await _db.Countries.FindAsync(code);

            if (countryItem == null)
            {
                throw new KeyNotFoundException(code);
            }

            _db.Countries.Remove(countryItem);

            await _db.SaveChangesAsync();
        }
    }
}