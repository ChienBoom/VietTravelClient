using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VietTravelClient.Common
{
    public class Convert
    {
        public string ConvertMoney(decimal value)
        {
            string moneyString = value.ToString();
            return moneyString;
        }
    }
}
