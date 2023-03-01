using Core.Interfaces.Persistence;
using Infrastructure.Persistence.CosmosDb;
using Infrastructure.Persistence.CosmosDb.Extensions;

namespace WebAPI.Config
{
    /// <summary>
    ///     Database related configurations
    /// </summary>
    public static class DatabaseConfig
    {
        /// <summary>
        ///     Setup Cosmos DB
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void SetupCosmosDb(this IServiceCollection services, IConfiguration configuration)
        {
            // Bind database-related bindings
            CosmosDbSettings cosmosDbConfig = configuration.GetSection("ConnectionStrings:CosmosDB").Get<CosmosDbSettings>();
            // register CosmosDB client and data repositories
            services.AddCosmosDb(cosmosDbConfig.EndpointUrl,
                                 cosmosDbConfig.PrimaryKey);

            services.AddScoped<ITicketRepository, TicketRepository>();
            // Audience: for you to follow through the code.
            //services.AddScoped<IWikiPageRepository, WikiPageRepository>();
        }
    }
}
