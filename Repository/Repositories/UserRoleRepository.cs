using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UserRoleRepository : BaseRepository<UserRole>, IUserRepository<UserRole>
    {
        public UserRoleRepository(Context context) : base(context)
        {
        }

     
    }
}
