using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

using Tenants.Infrastructure.Constants;

namespace Tenants.Infrastructure.Data
{
    public class DesignTimeApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Retrieve the connection string from the args array
            var connectionString = args.Length > 0 ? args[0] : null;

            if (string.IsNullOrEmpty(connectionString))
            {
                // Retrieve the connection from the environment variable, if it exists
                connectionString = Environment.GetEnvironmentVariable(Database.ConnectionStringName);
            }


            if (string.IsNullOrEmpty(connectionString))
            {
                // If the connection string is not found, retrieve it from the appsettings.json file
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                connectionString = configuration.GetConnectionString(Database.ConnectionStringName);
            }

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException($"Could not find a connection string named '{Database.ConnectionStringName}'.");
            }

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
