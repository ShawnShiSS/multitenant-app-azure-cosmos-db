namespace Infrastructure.Persistence.CosmosDb
{
    public class CosmosDbSettings
    {
        /// <summary>
        ///     CosmosDb Account - The Azure Cosmos DB endpoint
        /// </summary>
        public string EndpointUrl { get; set; }
        /// <summary>
        ///     Key - The primary key for the Azure DocumentDB account.
        /// </summary>
        public string PrimaryKey { get; set; }
        
    }

}
