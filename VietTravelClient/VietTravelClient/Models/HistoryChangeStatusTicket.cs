using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VietTravelClient.Models
{
    public class HistoryChangeStatusTicket
    {
        public long Id { get; set; }
        public DateTime TimeChange { get; set; }
        public long ChangeBy { get; set; }
        public User User { get; set; }
        public long TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public int oldStatus { get; set; }
        public int newStatus { get; set; }
    }
}
