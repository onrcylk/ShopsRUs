using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Common.Dto.Customers
{
    public class CustomerRoleDto
    {
        public string CustomerRoleName { get; set; }
        public int Statu { get; set; }

        [JsonIgnore]
        public virtual ICollection<CustomersDto> CustomersDto { get; set; }

    }
}
