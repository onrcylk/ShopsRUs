using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            UserRole = new HashSet<UserRole>();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }

        public virtual ICollection<UserRole> UserRole { get; set; }

    }
}
