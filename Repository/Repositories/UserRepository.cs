using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository<User>
    {
        public UserRepository(Context context) : base(context)
        {
        }

        public async Task<User> GetByEmailAddressAsync(string emailAddress)
        {
            return await dbSet.FirstOrDefaultAsync(x => x.Email == emailAddress && !x.isDeleted);
        }
        public async Task<User> GetByRefreshTokenAsync(string refreshToken)
        {
            return await dbSet.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken && !x.isDeleted);
        }
    }
}
