using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IUserRepository<Role>
    {
        public RoleRepository(Context context) : base(context)
        {
        }

     
    }
}
