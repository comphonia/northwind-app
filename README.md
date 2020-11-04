# Northwind-App

Developed by Everistus Akpabio

## Description
Northwind-app is a minimal application that demonstrates the use of ASP .NET Core MVC, ASP .NET Identity, Entity Framework Core
& the [Northwind Database](https://github.com/microsoft/sql-server-samples/tree/master/samples/databases/northwind-pubs).

For more info see the `./documentation` folder

### Instructions for local setup

- Clone [This Repo](https://github.com/comphonia/northwind-app)
- Open the solution `northwind-app/NorthwindApp` in Visual Studio

#### Setup the database
- Download the Northwind database from https://github.com/Microsoft/sql-server-samples/tree/master/samples/databases/northwind-pubs
- Run the  `instnwnd.sql` script in you Sql Server Object Explorer under your `(localdb)\MSSQLLocalDB;` server instance.
- Ensure that the `Northwind` database is installed after the script has been run.
- Check your connection string to make sure it matches up with the `NorthwindDbConnection` in `appsettings.json`
    `"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;"`
- Apply migrations using the Package Manager `Update-Database -Context ApplicationDbContext`
- Run the app in release mode!
