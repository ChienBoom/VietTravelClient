using System.ComponentModel.DataAnnotations;
using System;

namespace VietTravelClient.Models
{
    public class Event
    {
        public long Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public long TourId { get; set; }
        public string Pictures { get; set; }
    }
}
