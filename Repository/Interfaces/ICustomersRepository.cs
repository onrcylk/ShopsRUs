using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface ICustomersRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
    }
}
