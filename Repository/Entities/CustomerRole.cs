using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities
{
    public class CustomerRole : BaseEntity
    {
     
        public string CustomerRoleName { get; set; }
        public int Statu { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }
    }
}
