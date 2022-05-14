using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Common.Dto.Customers
{
    public class CustomerRoleDto
    {
        public string CustomerRoleName { get; set; }
        public string Desc { get; set; }

        [JsonIgnore]
        public virtual ICollection<CustomersDto> CustomersDto { get; set; }

    }
}
