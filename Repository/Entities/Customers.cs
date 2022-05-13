using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities
{
    public class Customers : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual CustomerRole CustomerRole { get; set; }

    }
}
