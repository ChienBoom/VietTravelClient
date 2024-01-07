using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VietTravelClient.Models
{
	public class Ticket
	{
		public long Id { get; set; }
		public DateTime BookingDate { get; set; }
		public string Description { get; set; }
		public long TourPackageId { get; set; }
		public long UserId { get; set; }
		public TourPackage TourPackage { get; set; }
		public User User { get; set; }
		//User cho phan ticketManagement
		public User UserTicket { get; set; }
		public int IsDelete { get; set; } // 1 là đã xóa, 0 là chưa xóa
		public int Status { get; set; } //1 la chua thanh toan, 2 la da thanh toan - chua hoan thanh tour, 3 la da hoan thanh tou
	}
}
