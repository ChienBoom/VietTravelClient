using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace VietTravelClient.Models
{
    public class Schedule
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int TicketEnable { get; set; }
        public decimal PriceTicketKid { get; set; }
        public decimal PriceTicketAdult { get; set; }
        public long TourId { get; set; }
        public string Pictures { get; set; }
        public int IsDelete { get; set; } // 1 là đã xóa, 0 là chưa xóa
    }
}
