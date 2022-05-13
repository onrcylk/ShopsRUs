using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class InvoicesRepository : BaseRepository<Invoices>, IUserRepository<Invoices>
    {
        public InvoicesRepository(Context context) : base(context)
        {
        }

     
    }
}
