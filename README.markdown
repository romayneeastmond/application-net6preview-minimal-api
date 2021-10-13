# ApplicationNET6PreviewSandbox Project

An ASP.NET Core project, created in Visual Studio 2022 preview, that uses .NET 6 ~~rc 1~~ rc 2 to demonstrate how to create a minimal Api. The project separates the concerns into the minimal Api layer, the database model layer, and then the business services layer.

Although the Program.cs file can be built without being opininated, there is more flexibility and readability with organizing the project this way. 

~~Note that early releases of .NET 6 do not support the .WithTags() extension method.~~ Grouping on the Api endpoints is achieved by using method groups instead of lambda expressions.

There are also calls to the new .NET 6 LINQ features such as MaxBy, MinBy, and Chunk.

###### LINQ Examples
```
var countries = await _db.Countries.Where(x => x.Population > 0).ToListAsync();

return countries.MaxBy(x => x.Population)!;
```
```
var countries = await _db.Countries.Where(x => x.Population > 0).ToListAsync();

return countries.MinBy(x => x.Population)!;
```
```
var countries = await _db.Countries.Where(x => x.Region == region).ToListAsync();

return countries.Chunk(10);
```

## How to Use

This project uses the preview edition of Visual Studio 2022 which should include the packages for .NET 6 ~~rc 1~~ rc 2. If other pre-release packages are available, then restore any available in NuGet before building or deploying. 

Ensure that the connection strings in the appsettings files are changed to point to the applicable instance. Then (optionally) generate or run the migrations found below. 

This project uses Swagger to describe the available mimimal Api endpoints.

###### Generate Migrations
```
Add-Migration InitialDatabase -Context CountryDbContext
Update-Database
```

## Known Issues

The migrations will not generate without explicitly setting the startup project to ApplicationNET6PreviewSandbox.Api, which will automatically use the CreateDbContext method found in the CountryDbContextFactory.

This might be a result of separating the DbContext concerns away from the Program.cs. Either way, these are expected issues when dealing with an early adopted approach.


## Copyright and Ownership

All terms used are copyright to their original authors.

## Live Demo

Live demo hosted in Microsoft Azure .NET 6 Early Access App Service [Minimal Api Demonstration](https://dev-net6preview-minimal-api-demo.azurewebsites.net/swagger/index.html).

## .NET 6 Release Candidate 2

.NET 6 rc 2 is available October 12, 2021 and should work with Visual Studio 2022 preview 5.0. 