using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities
{
    public class Discount : BaseEntity
    {
        public string DiscountName { get; set; }
        public string ScopeType { get; set; }
       
    }
}
