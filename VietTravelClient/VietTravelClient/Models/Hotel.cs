using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VietTravelClient.Models
{
	public class Hotel
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
		public decimal PriceHour { get; set; }
		public int IsDelete { get; set; } // 1 là đã xóa, 0 là chưa xóa
		public int NumberOfEvaluate { get; set; }
		public int NumberOfEvaluateStar { get; set; }
		public float MediumStar { get; set; }
		//
		//public int TotalRoom { get; set; }
		//public int VipRoom { get; set; }
		//public int NormalRoom { get; set; }
		//public int RemainingVipRoom { get; set; }
		//public int RemainingNormalRoom { get; set; }
		//public decimal PriceVipRoom { get; set; }
		//public decimal PriceNormalRoom { get; set; }
	}
}
