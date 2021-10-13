using ApplicationNET6PreviewSandbox.Models;
using ApplicationNET6PreviewSandbox.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CountryDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("CountryDbString"),
        migrations => migrations.MigrationsAssembly("ApplicationNET6PreviewSandbox.Models")
    )
);

var countryDbContext = new CountryDbContext(builder.Services.BuildServiceProvider().GetRequiredService<DbContextOptions<CountryDbContext>>());

countryDbContext.Database.Migrate();

CountryInitalizer.Initialize(countryDbContext);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "ApplicationNET6PreviewSandbox.Api", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApplicationNET6PreviewSandbox.Api v1"));

app.UseHttpsRedirection();

app.MapGet("/application/ungrouped", () =>
{
    return "Hello World, the default ungrouped behaviour.";
});

app.MapPost("/application/ungrouped", () =>
{
    return "Hello World, the default ungrouped behaviour (Post).";
});

app.MapDelete("/administration/rebuild", Rebuild)
    .WithTags("Administration"); 

static async Task<IResult> Rebuild(CountryDbContext db)
{
    await new CountryService(db).Rebuild();

    return Results.StatusCode(204);
};

app.AddRoutesApplication();
app.AddRoutesCountries();
app.AddRoutesPopulation();

app.Run();