using Core.Enums;

namespace WebAPI.Models.Ticket
{
    public class TicketModel
    {
        public string Id { get; set; }

        public string TenantId { get; set; }

        /// <summary>
        ///     Name of support ticket.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Ticket status.
        /// </summary>
        public TicketStatus Status { get; set; }

        /// <summary>
        ///     User who is assigned to this ticket.
        /// </summary>
        public string Assignee { get; set; }
    }
}
