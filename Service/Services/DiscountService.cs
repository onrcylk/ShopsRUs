using Common;
using Common.Dto.Token;
using Common.Dto.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class DiscountService : BaseService, IBaseService<Discount>
    {
        public DiscountService(ServiceContext serviceContext, IServiceManager serviceManager) : base(serviceContext, serviceManager)
        {

        }
        public async Task<ServiceResult<Discount>> CreateAsync(Discount entity)
        {
            if (entity == null)
                return new ServiceResult<Discount>(null, false, "Discount info is empty!");

            try
            {
                Discount checkEntity;
                if (entity.Id > 0)
                {
                    checkEntity = await repositoryManager.DiscountRepository.GetByIDAsync(entity.Id);
                    if (checkEntity != null)
                        return new ServiceResult<Discount>(null, false, "Discount already exist!");
                    else
                        entity.Id = 0;
                }

                await repositoryManager.DiscountRepository.InsertAsync(entity);
                await repositoryManager.CommitAsync();


                return new ServiceResult<Discount>(entity, true);
            }
            catch (Exception ex)
            {
                return new ServiceResult<Discount>(null, false, ex.Message);
            }
        }

        public Task<ServiceResult> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<IEnumerable<Discount>>> GetAsync(Expression<Func<Discount, bool>> filter = null, Func<IQueryable<Discount>, IOrderedQueryable<Discount>> orderBy = null, params Expression<Func<Discount, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<Discount>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<IEnumerable<Discount>>> GetListAsync(FilterCriteria filterCriteria, Expression<Func<Discount, bool>> predicateQuery = null)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> UpdateAsync(int id, Discount entity)
        {
            throw new NotImplementedException();
        }
    }
}
