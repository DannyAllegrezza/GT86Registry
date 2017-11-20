# GT86Registry.com
A project to test out the *current* iterations of .NET Core, Web API, and some fun Javascript framework. The end goal is to create a light weight, modern, cross-platform library that caters to automotive enthusiasts. 

## Architecture
The end goal is to create a modular library that can easy be extended to create additional websites for different vehicles, but for now all functionality of the core library is encapsulated in this project. I may iterate in the future and break this apart, but for the sake of quick-iterations, I have encapsulated all major functionality into this one project. 

This project follows an onion architecture. 

<img src="img/onion.JPG">
*Image borrowed from* [Architecting Modern Web Applications with ASP.NET Core and Azure eBook](https://aka.ms/webappebook).

### Data access layer
Currently, the library is using Entity Framework Core 2 as an ORM. EF Core has many different database drivers, I'm happening to use SQL Server but you could easily swap it out for Postgres, SQLite and others. 

#### Creating the migrations
The migrations are already created for this project, but if they need to be created again you can follow the following steps:
1. Run the following commands from the `src\GT86Registry.Web` folder
* `dotnet ef migrations add InitialIdentityModel --context AppIdentityDbContext -p ..\GT86Registry.Infrastructure\GT86Registry.Infrastructure.csproj -s GT86Registry.Web.csproj -o Identity/Migrations`
* `dotnet ef migrations add InitialVehicleModel --context VehicleDbContext -p ..\GT86Registry.Infrastructure\GT86Registry.Infrastructure.csproj -s GT86Registry.Web.csproj -o Data/Migrations`

If the Migrations have already been created, follow these steps:
1. Run the following commands from the `src\GT86Registry.Web` folder
* `dotnet restore`
* `dotnet ef database update -c CarDbContext -p ..\GT86Registry.Infrastructure\GT86Registry.Infrastructure.csproj -s GT86Registry.Web.csproj`
* `dotnet ef database update -c AppIdentityDbContext -p ..\GT86Registry.Infrastructure\GT86Registry.Infrastructure.csproj -s GT86Registry.Web.csproj`

This should create 2 new databases:
1. `GT86Registry.Identity`
2. `GT86Registry.CarRegistry`
## Motivation
This project came from my desire to test out some of the new functionality of the latest .NET Core 2 offerings through a domain which I love dearly, automobiles. As some may already know, I'm a huge gearhead and have been turning wrenches on cars since age 16, right along side tinkering with computer hardware. 
