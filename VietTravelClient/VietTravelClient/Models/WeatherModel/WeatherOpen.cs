using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VietTravelClient.Models.WeatherModel
{
    public class WeatherOpen
    {
        public Coord Coord { get; set; } // Kinh độ vĩ độ
        public List<Weather> Weather { get; set; } //Thời tiết
        public string Base { get; set; } // Tham số nội bộ
        public Main Main { get; set; } // Nội dung chính
        public int Visibility { get; set; } // Tầm nhìn
        public Wind Wind { get; set; } //Gios
        public Clouds Clouds { get; set; } //Độ đục
        public long Dt { get; set; } // Thời gian tính taosn dữ liệu
        public Sys Sys { get; set; } //Tham số nội bộ
        public long Timezone { get; set; } //Thay đổi tính bằng giây
        public long Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }
}
