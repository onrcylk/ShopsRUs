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
    public class CustomerRoleService : BaseService, IBaseService<CustomerRole>
    {
        public CustomerRoleService(ServiceContext serviceContext, IServiceManager serviceManager) : base(serviceContext, serviceManager)
        {

        }
        public async Task<ServiceResult<CustomerRole>> CreateAsync(CustomerRole entity)
        {
            if (entity == null)
                return new ServiceResult<CustomerRole>(null, false, "CustomerRole info is empty!");

            try
            {
                CustomerRole checkEntity;
                if (entity.Id > 0)
                {
                    checkEntity = await repositoryManager.CustomerRoleRepository.GetByIDAsync(entity.Id);
                    if (checkEntity != null)
                        return new ServiceResult<CustomerRole>(null, false, "Discount already exist!");
                    else
                        entity.Id = 0;
                }

                await repositoryManager.CustomerRoleRepository.InsertAsync(entity);
                await repositoryManager.CommitAsync();


                return new ServiceResult<CustomerRole>(entity, true);
            }
            catch (Exception ex)
            {
                return new ServiceResult<CustomerRole>(null, false, ex.Message);
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

        public Task<ServiceResult<IEnumerable<CustomerRole>>> GetAsync(Expression<Func<CustomerRole, bool>> filter = null, Func<IQueryable<CustomerRole>, IOrderedQueryable<CustomerRole>> orderBy = null, params Expression<Func<CustomerRole, object>>[] includeProperties)
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

        public Task<ServiceResult<IEnumerable<CustomerRole>>> GetListAsync(FilterCriteria filterCriteria, Expression<Func<CustomerRole, bool>> predicateQuery = null)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> UpdateAsync(int id, Discount entity)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> UpdateAsync(int id, CustomerRole entity)
        {
            throw new NotImplementedException();
        }

        Task<ServiceResult<CustomerRole>> IBaseService<CustomerRole>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
