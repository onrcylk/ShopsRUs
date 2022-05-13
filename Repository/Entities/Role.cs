using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities
{
    public class Role : BaseEntity
    {
        public Role()
        {
            UserRole = new HashSet<UserRole>();
        }
        public string RoleName { get; set; }
        public string Desc { get; set; }

        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
