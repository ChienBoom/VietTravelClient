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
        public decimal BasePrice { get; set; }
        public float Discount { get; set; }
        public decimal LastPrice { get; set; }
        public long TourId { get; set; }
        public long HotelId { get; set; }
        public long TimePackageId { get; set; }
    }
}
