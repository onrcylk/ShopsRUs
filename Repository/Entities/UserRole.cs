using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities
{
    public class UserRole : BaseEntity
    {
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
