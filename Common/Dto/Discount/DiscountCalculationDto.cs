using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Common.Dto.Discount
{
   public class DiscountCalculationDto
    {
        public int CustomerType { get; set; }
        public double TotalAmount { get; set; }
        [JsonIgnore]
        public double? DiscountAmount { get; set; }
        [JsonIgnore]
        public double? DiscountRate { get; set; }
        [JsonIgnore]
        public double DiscountFiveOffForEveryOneHundered { get; set; }
        [JsonIgnore]
        public double? TotarialPayment { get; set; }
        
    }
}
