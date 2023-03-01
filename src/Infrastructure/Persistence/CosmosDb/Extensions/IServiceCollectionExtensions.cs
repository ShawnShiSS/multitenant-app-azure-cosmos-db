using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence.CosmosDb.Extensions
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        ///     Register a singleton instance of CosmosClient.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="endpointUrl"></param>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public static IServiceCollection AddCosmosDb(this IServiceCollection services,
                                                     string endpointUrl,
                                                     string primaryKey)
        {
            Microsoft.Azure.Cosmos.CosmosClient client = new Microsoft.Azure.Cosmos.CosmosClient(endpointUrl, primaryKey);
            
            // Microsoft recommends a singleton client instance to be used throughout the application
            // https://docs.microsoft.com/en-us/dotnet/api/microsoft.azure.cosmos.cosmosclient?view=azure-dotnet#definition
            // "CosmosClient is thread-safe. Its recommended to maintain a single instance of CosmosClient per lifetime of the application which enables efficient connection management and performance"
            services.AddSingleton<Microsoft.Azure.Cosmos.CosmosClient>(client);

            return services;
        }
    }
}
