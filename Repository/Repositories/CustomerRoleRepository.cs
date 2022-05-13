using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CustomerRoleRepository : BaseRepository<CustomerRole>, IUserRepository<CustomerRole>
    {
        public CustomerRoleRepository(Context context) : base(context)
        {
        }

     
    }
}
