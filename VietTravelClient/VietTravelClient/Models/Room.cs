using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VietTravelClient.Models
{
    public class Room
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int IsActive { get; set; }
        public int IsDelete { get; set; }
    }
}
