namespace Infrastructure.Persistence.CosmosDb
{
    /// <summary>
    ///     Constants used for Cosmos DB setup.
    /// </summary>
    public class CosmosDbConstants
    {
        public static readonly string DatabaseName = "TicketTrackingPlatform";

        public static readonly string DataContainerName = "Data";
        public static readonly string DataContainerPartitionKey = "/TenantId";

        public static readonly string DefaultTenantId = "644d71f1-52c7-4423-a6a2-464323654370";
    }
}
