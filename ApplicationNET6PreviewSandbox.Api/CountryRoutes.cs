using ApplicationNET6PreviewSandbox.Models;
using ApplicationNET6PreviewSandbox.Services;

public static class Countries
{
    public static void AddRoutesCountries(this WebApplication app)
    {
        app.MapGet("/countries", Get);

        app.MapGet("/countries/{code}", GetByCode);

        app.MapGet("/countries/region/{region}", GetByRegion);

        app.MapPost("/countries/insert", Insert);

        app.MapPut("/countries/update", Update);

        app.MapDelete("/countries/delete", Delete);

        static async Task<IResult> Get(ICountryService countryService)
        {
            return await countryService.Get() is List<Country> countries ? Results.Ok(countries) : Results.Ok(new List<Country>());
        };

        static async Task<IResult> GetByCode(ICountryService countryService, string code)
        {
            return await countryService.Get(code) is Country country ? Results.Ok(country) : Results.NotFound();
        };

        static async Task<IResult> GetByRegion(ICountryService countryService, string region)
        {
            return await countryService.GetByRegion(region) is IEnumerable<Country[]> regions ? Results.Ok(regions) : Results.NotFound();
        }

        static async Task<IResult> Insert(ICountryService countryService, Country country)
        {
            await countryService.Insert(country);

            return Results.Created($"/countries/{country.Code}", country);
        };

        static async Task<IResult> Update(ICountryService countryService, string code, Country country)
        {
            await countryService.Update(code, country);

            return Results.StatusCode(204);
        };

        static async Task<IResult> Delete(ICountryService countryService, string code)
        {
            await countryService.Delete(code);

            return Results.StatusCode(204);
        };
    }
}

