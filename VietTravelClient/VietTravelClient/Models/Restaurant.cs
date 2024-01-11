namespace VietTravelClient.Models
{
    public class Restaurant
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string TitleIntroduct { get; set; }
        public string ContentIntroduct { get; set; }
        public long CityId { get; set; }
        public string Pictures { get; set; }
        public string UniCodeName { get; set; }
        public decimal PriceDefault { get; set; }
        public int IsDelete { get; set; } // 1 là đã xóa, 0 là chưa xóa
        public int NumberOfEvaluate { get; set; }
        public int NumberOfEvaluateStar { get; set; }
        public float MediumStar { get; set; }
        //
        //public int TotalTable { get; set; }
        //public int TotalVipTable { get; set; }
        //public int TotalNormalTabel { get; set; }
        //public int VipTableSix { get; set; }
        //public int VipTableTen { get; set; }
        //public int NormalTabelSix { get; set; }
        //public int NormalTabelTen { get; set; }
        //public int RemainingVipTable { get; set; }
        //public int RemainingNormalTable { get; set; }
        //public decimal PriceVipTableSix { get; set; }
        //public decimal PriceVipTableTen { get; set; }
        //public decimal PriceNormalTableSix { get; set; }
        //public decimal PriceNormalTableTen { get; set; }
    }
}
