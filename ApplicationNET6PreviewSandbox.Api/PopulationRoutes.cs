using ApplicationNET6PreviewSandbox.Models;
using ApplicationNET6PreviewSandbox.Services;

public static class Population
{
    public static void AddRoutesPopulation(this WebApplication app)
    {
        app.MapGet("/population/get/maximum", Maximum);

        app.MapGet("/population/get/minimum", Minimum);

        static async Task<IResult> Maximum(IPopulationService populationService)
        {
            return await populationService.Maximum() is Country country ? Results.Ok(country) : Results.Ok(0);
        }

        static async Task<IResult> Minimum(IPopulationService populationService)
        {
            return await populationService.Minimum() is Country country ? Results.Ok(country) : Results.Ok(0);
        }
    }
}