using ApplicationNET6PreviewSandbox.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ApplicationNET6PreviewSandbox.Api
{
    public class CountryDbContextFactory : IDesignTimeDbContextFactory<CountryDbContext>
    {
        public CountryDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();

            var connectionString = configuration.GetConnectionString("CountryDbString");

            var builder = new DbContextOptionsBuilder<CountryDbContext>();

            builder.UseSqlServer(connectionString);

            return new CountryDbContext(builder.Options);
        }
    }
}