using Common.Dto.Discount;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Common.Dto.Invoice
{
    public class InvoiceDto
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string Salesperson { get; set; }
        public int OrderID { get; set; }
        public string ShipperName { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        [JsonIgnore]
        public double TotalAmount { get; set; }
        [JsonIgnore]
        public double DiscountAmount { get; set; }
        [JsonIgnore]
        public double TotarialPayment { get; set; }

        [JsonIgnore]
        public virtual ICollection<DiscountDto> Discounts { get; set; }
    }
}
