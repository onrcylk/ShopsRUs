using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CustomersRepository : BaseRepository<Customers>, IUserRepository<Customers>
    {
        public CustomersRepository(Context context) : base(context)
        {
        }

        public  Task<Customers> GetByEmailAddressAsync(string emailAddress)
        {
            return  dbSet.FirstOrDefaultAsync(x => x.Email == emailAddress && !x.isDeleted);
        }
     
    }
}
