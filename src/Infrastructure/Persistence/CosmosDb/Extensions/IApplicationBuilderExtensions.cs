using Core.Entities;
using Core.Interfaces.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence.CosmosDb.Extensions
{
    /// <summary>
    ///     Extension methods for application builder. 
    /// </summary>
    public static class IApplicationBuilderExtensions
    {
        /// <summary>
        ///     Ensure Cosmos DB is created
        /// </summary>
        /// <param name="builder"></param>
        public static async Task EnsureCosmosDbIsCreated(this IApplicationBuilder builder)
        {
            using (IServiceScope serviceScope = builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                // This should be a singleton instance
                Microsoft.Azure.Cosmos.CosmosClient cosmosClient = serviceScope.ServiceProvider.GetService<Microsoft.Azure.Cosmos.CosmosClient>();

                // Create the database
                Microsoft.Azure.Cosmos.DatabaseResponse database = await cosmosClient.CreateDatabaseIfNotExistsAsync(CosmosDbConstants.DatabaseName);

                // Create the container(s)
                await database.Database.CreateContainerIfNotExistsAsync(CosmosDbConstants.DataContainerName, CosmosDbConstants.DataContainerPartitionKey);
            }
        }

        /// <summary>
        ///     Seed sample data in the Data container
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static async Task SeedDataContainerIfEmptyAsync(this IApplicationBuilder builder)
        {
            using (IServiceScope serviceScope = builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                ITicketRepository _repo = serviceScope.ServiceProvider.GetService<ITicketRepository>();

                // Check if empty
                string sqlQueryText = "SELECT * FROM c";
                IEnumerable<Ticket> tickets = await _repo.GetItemsAsync(sqlQueryText);

                if (tickets != null && tickets.Count() > 0)
                {
                    return;
                }

                // Seed
                string defaultTenantId = CosmosDbConstants.DefaultTenantId;

                await _repo.AddItemAsync(new Ticket()
                {
                    TenantId = defaultTenantId,
                    Name = "Default ticket",
                    Status = Core.Enums.TicketStatus.New
                });

                await _repo.AddItemAsync(new Ticket()
                {
                    TenantId = defaultTenantId,
                    Name = "Default ticket 2",
                    Status = Core.Enums.TicketStatus.Acknowledged
                });
            }
        }
    }
}
