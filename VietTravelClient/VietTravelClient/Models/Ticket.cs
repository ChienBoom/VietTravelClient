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
    }
}
