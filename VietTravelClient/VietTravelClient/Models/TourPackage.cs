using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VietTravelClient.Models
{
    public class TourPackage
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public int NumberOfAdult { get; set; }
        public int NumberOfChildren { get; set; }
        public decimal TotalPrice { get; set; }
        public long TourId { get; set; }
        public Tour Tour { get; set; }
        public long HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public long TimePackageId { get; set; }
        public TimePackage  TimePackage { get; set; }
        public Ticket Ticket { get; set; }
    }
}
