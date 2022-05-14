using Common.Dto.Discount;
using System;
using System.Collections.Generic;
using System.Text;

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
    
        public virtual ICollection<DiscountDto> Discounts { get; set; }
    }
}
