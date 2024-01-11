using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VietTravelClient.Models
{
    public class Voucher
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Active { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime StartTime { get; set; }
        public float Sale { get; set; }
        public int IsDelete { get; set; }
    }
}
