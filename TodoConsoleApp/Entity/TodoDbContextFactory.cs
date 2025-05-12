using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TodoConsoleApp.Entity;

/**
 *
 * The TodoDbContextFactory class is specifically for design-time operations like migrations.
 * EF Core uses it to create a DbContext without needing runtime services.
 * It is not called directly by your app, but by tools like dotnet ef when you work with migrations or database updates.
 */
public class TodoDbContextFactory : IDesignTimeDbContextFactory<TodoDbContext>
{
    public TodoDbContext CreateDbContext(string[] args)
    {
        // Build the configuration to retrieve the connection string
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json") // Use your actual config file if available
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<TodoDbContext>();

        // Use SQL Server with the connection string from appsettings or environment variables
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

        return new TodoDbContext(optionsBuilder.Options);
    }
}