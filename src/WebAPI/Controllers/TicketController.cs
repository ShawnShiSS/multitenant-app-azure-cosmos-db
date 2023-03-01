using Core.Interfaces.Persistence;
using Infrastructure.Persistence.CosmosDb;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.Ticket;

namespace WebAPI.Controllers
{

    /// <summary>
    ///     Ticket controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketController(ITicketRepository ticketRepository)
        {
            this._ticketRepository = ticketRepository ?? throw new ArgumentNullException(nameof(ticketRepository));
        }

        // GET: api/Ticket/5
        /// <summary>
        ///     Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetTicket")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<TicketModel>> Get(string id)
        {
            Core.Entities.Ticket ticket = await _ticketRepository.GetItemAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return new TicketModel() 
            {
                Id = ticket.Id,
                TenantId = ticket.TenantId,
                Name = ticket.Name,
                Status = ticket.Status,
                Assignee = ticket.Assignee
            };

        }

        // GET: api/ticket
        /// <summary>
        ///     Get all
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IEnumerable<TicketModel>> GetAll()
        {
            // TODO : get tenant id from access token 
            string tenantId = CosmosDbConstants.DefaultTenantId;
            string sqlQueryText = @$"SELECT * FROM c where c.Tenant = {tenantId}";
            IEnumerable<Core.Entities.Ticket> tickets = await _ticketRepository.GetItemsAsync(sqlQueryText);
            
            return tickets.Select(ticket => new TicketModel()
            {
                Id = ticket.Id,
                TenantId = ticket.TenantId,
                Name = ticket.Name,
                Status = ticket.Status,
                Assignee = ticket.Assignee
            });

        }
    }
}
