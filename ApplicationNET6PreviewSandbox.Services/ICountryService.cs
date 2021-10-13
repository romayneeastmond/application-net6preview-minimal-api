using ApplicationNET6PreviewSandbox.Models;

namespace ApplicationNET6PreviewSandbox.Services
{
    public interface ICountryService
    {
        Task<List<Country>> Get();

        Task<Country> Get(string code);

        Task<IEnumerable<Country[]>> GetByRegion(string region);

        Task<Country> Insert(Country country);

        Task Update(string code, Country country);

        Task Delete(string code);

        Task Rebuild();
    }
}
