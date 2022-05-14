using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Common.Dto.Customers
{
    public class CustomersDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int CustomerStatu { get; set; }

        [JsonIgnore]
        public virtual CustomerRoleDto CustomerRoleDto { get; set; }

    }
}
