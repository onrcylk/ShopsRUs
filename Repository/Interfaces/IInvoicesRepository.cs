using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IInvoicesRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
    }
}
