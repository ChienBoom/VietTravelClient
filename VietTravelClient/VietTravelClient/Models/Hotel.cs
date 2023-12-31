﻿using System.Collections.Generic;
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
    }
}
