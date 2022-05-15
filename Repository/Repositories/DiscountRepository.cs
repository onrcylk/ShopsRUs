using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class DiscountRepository : BaseRepository<Discount>, IUserRepository<Discount>
    {
        public DiscountRepository(Context context) : base(context)
        {
        }
        public Task<Discount> GetByDiscount(int statu)
        {
            return dbSet.FirstOrDefaultAsync(x => x.Statu == statu && !x.isDeleted);
        }


    }
}
