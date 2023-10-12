using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VietTravelClient.Models
{
	public class Evaluate
	{
        public long Id { get; set; }
        public int Eva { get; set; } //Đánh giá Thành Phố/ Tour/ Khách sạn/ Nhà hàng theo thứ tự 1/2/3/4 - 0 là không đánh giá
        public string Content { get; set; }
        public long EvaId { get; set; } // Id của Thành phố/ Tour/ Khách sạn/ Nhà hàng được đánh giá
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
