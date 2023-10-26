using System;

namespace VietTravelClient.ModelsDto
{
    public class TourPackageDto
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public int NumberOfAdult { get; set; }
        public int NumberOfChildren { get; set; }
        public long Discount { get; set; }
        public long TourId { get; set; }
        public long HotelId { get; set; }
        public long RestaurantId { get; set; }
        public long TimePackageId { get; set; }
        public string Description { get; set; }
    }
}
