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

        static async Task<IResult> Get(CountryDbContext db)
        {
            return await new CountryService(db).Get() is List<Country> countries ? Results.Ok(countries) : Results.Ok(new List<Country>());
        };

        static async Task<IResult> GetByCode(CountryDbContext db, string code)
        {
            return await new CountryService(db).Get(code) is Country country ? Results.Ok(country) : Results.NotFound();
        };

        static async Task<IEnumerable<Country[]>> GetByRegion(CountryDbContext db, string region)
        {
            return await new CountryService(db).GetByRegion(region);
        }

        static async Task<IResult> Insert(CountryDbContext db, Country country)
        {
            await new CountryService(db).Insert(country);

            return Results.Created($"/countries/{country.Code}", country);
        };

        static async Task<IResult> Update(CountryDbContext db, string code, Country country)
        {
            await new CountryService(db).Update(code, country);

            return Results.StatusCode(204);
        };

        static async Task<IResult> Delete(CountryDbContext db, string code)
        {
            await new CountryService(db).Delete(code);

            return Results.StatusCode(204);
        };
    }
}

