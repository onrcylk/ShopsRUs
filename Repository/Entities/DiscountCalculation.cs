using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities
{
    public class DiscountCalculation : BaseEntity
    {
        public int CustomerType { get; set; }
        public double TotalAmount { get; set; }
        public double? DiscountAmount { get; set; }
        public double? DiscountRate { get; set; }
        public double DiscountFiveOffForEveryOneHundered { get; set; }
        public double? TotarialPayment { get; set; }
    }
}
