using Core.Enums;

namespace Core.Entities
{
    public class Ticket : BaseEntity
    {
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
