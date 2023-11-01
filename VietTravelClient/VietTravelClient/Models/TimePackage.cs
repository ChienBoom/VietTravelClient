using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VietTravelClient.Models
{
    public class TimePackage
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int HourNumber { get; set; }
        public string Description { get; set; }
        public int IsDelete { get; set; } // 1 là đã xóa, 0 là chưa xóa
    }
}
