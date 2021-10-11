using ApplicationNET6PreviewSandbox.Models;
using ApplicationNET6PreviewSandbox.Services;

public static class Population
{
    public static void AddRoutesPopulation(this WebApplication app)
    {
        app.MapGet("/population/get/maximum", Maximum);

        app.MapGet("/population/get/minimum", Minimum);

        static async Task<IResult> Maximum(CountryDbContext db)
        {
            return await new PopulationService(db).Maximum() is Country country ? Results.Ok(country) : Results.Ok(0);
        }

        static async Task<IResult> Minimum(CountryDbContext db)
        {
            return await new PopulationService(db).Minimum() is Country country ? Results.Ok(country) : Results.Ok(0);
        }
    }
}