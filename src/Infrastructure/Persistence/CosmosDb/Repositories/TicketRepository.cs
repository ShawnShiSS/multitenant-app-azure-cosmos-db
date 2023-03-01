using Core.Interfaces.Persistence;
using Core.Entities;
using Microsoft.Azure.Cosmos;

namespace Infrastructure.Persistence.CosmosDb
{
    public class TicketRepository : CosmosDbRepository<Ticket>, ITicketRepository
    {
        /// <summary>
        ///     Name of the Cosmos DB container where ticket data is stored.
        /// </summary>
        public override string ContainerName => CosmosDbConstants.DataContainerName;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="cosmosClient"></param>
        public TicketRepository(CosmosClient cosmosClient) : base(cosmosClient)
        {
        }


        public override string GenerateId(Ticket entity)
        {
            // Two parts: tenant id, new guid.
            return $"{entity.TenantId}:{Guid.NewGuid()}";
        }

        public override PartitionKey ResolvePartitionKey(string entityId)
        {
            // First part of the item id.
            string[] idComponents = entityId.Split(':');
            return new PartitionKey(idComponents[0]);
        }
    }
}
