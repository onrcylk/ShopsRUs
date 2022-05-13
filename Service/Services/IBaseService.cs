using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace Service.Services
{
    public interface IBaseService<TEntity>
    {
        Task<ServiceResult<IEnumerable<TEntity>>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includeProperties);

        Task<ServiceResult<TEntity>> GetByIdAsync(int id);
        Task<ServiceResult<TEntity>> CreateAsync(TEntity entity);
        Task<ServiceResult> UpdateAsync(int id, TEntity entity);
        Task<ServiceResult> DeleteAsync(int id);
        Task<ServiceResult<IEnumerable<TEntity>>> GetListAsync(FilterCriteria filterCriteria, Expression<Func<TEntity, bool>> predicateQuery = null);
    }
}
