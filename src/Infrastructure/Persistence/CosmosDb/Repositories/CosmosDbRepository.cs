using Core.Interfaces.Persistence;
using Core.Entities;
using Microsoft.Azure.Cosmos;

namespace Infrastructure.Persistence.CosmosDb
{
    /// <summary>
    ///     Abstract repository to work with Cosmos DB.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CosmosDbRepository<T> : IRepository<T> where T : BaseEntity
    {
        /// <summary>
        ///     Actual Cosmos DB container that allows us to interact with the database.
        /// </summary>
        private readonly Microsoft.Azure.Cosmos.Container _container;

        /// <summary>
        ///     Name of the CosmosDB container we are working with.
        /// </summary>
        public abstract string ContainerName { get; }

        /// <summary>
        ///     Constructor 
        /// </summary>
        /// <param name="cosmosClient">Singleton instance of the CosmosClient from SDK.</param>
        public CosmosDbRepository(Microsoft.Azure.Cosmos.CosmosClient cosmosClient)
        {
            this._container = cosmosClient.GetContainer(CosmosDbConstants.DatabaseName, ContainerName);
        }

        /// <summary>
        ///     Generate id for an item.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract string GenerateId(T entity);

        /// <summary>
        ///     Resolve the partition key from the item id.
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public abstract Microsoft.Azure.Cosmos.PartitionKey ResolvePartitionKey(string entityId);

        public async Task AddItemAsync(T item)
        {
            item.Id = GenerateId(item);
            await _container.CreateItemAsync<T>(item, ResolvePartitionKey(item.Id));
        }

        public async Task DeleteItemAsync(string id)
        {
            await this._container.DeleteItemAsync<T>(id, ResolvePartitionKey(id));
        }

        public async Task<T> GetItemAsync(string id)
        {
            try
            {
                ItemResponse<T> response = await _container.ReadItemAsync<T>(id, ResolvePartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task UpdateItemAsync(string id, T item)
        {
            // Update
            await this._container.UpsertItemAsync<T>(item, ResolvePartitionKey(id));
        }

        // Search data using SQL query string
        public async Task<IEnumerable<T>> GetItemsAsync(string queryString)
        {
            FeedIterator<T> resultSetIterator = _container.GetItemQueryIterator<T>(new QueryDefinition(queryString));
            List<T> results = new List<T>();
            while (resultSetIterator.HasMoreResults)
            {
                FeedResponse<T> response = await resultSetIterator.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }
    }
}
