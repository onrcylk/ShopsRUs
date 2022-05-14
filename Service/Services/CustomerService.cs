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
    public class CustomerService : BaseService, IBaseService<Customers>
    {
        public CustomerService(ServiceContext serviceContext, IServiceManager serviceManager) : base(serviceContext, serviceManager)
        {

        }
        public async Task<ServiceResult<Customers>> CreateAsync(Customers entity)
        {
            if (entity == null)
                return new ServiceResult<Customers>(null, false, "Customer info is empty!");

            try
            {
                Customers checkEntity;
                if (entity.Id > 0)
                {
                    checkEntity = await repositoryManager.CustomersRepository.GetByIDAsync(entity.Id);
                    if (checkEntity != null)
                        return new ServiceResult<Customers>(null, false, "Invoice already exist!");
                    else
                        entity.Id = 0;
                }

                await repositoryManager.CustomersRepository.InsertAsync(entity);
                await repositoryManager.CommitAsync();


                return new ServiceResult<Customers>(entity, true);
            }
            catch (Exception ex)
            {
                return new ServiceResult<Customers>(null, false, ex.Message);
            }
        }

        public Task<ServiceResult> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<IEnumerable<Customers>>> GetAsync(Expression<Func<Customers, bool>> filter = null, Func<IQueryable<Customers>, IOrderedQueryable<Customers>> orderBy = null, params Expression<Func<Customers, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

    

        public Task<ServiceResult<IEnumerable<Customers>>> GetListAsync(FilterCriteria filterCriteria, Expression<Func<Customers, bool>> predicateQuery = null)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> UpdateAsync(int id, Invoices entity)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> UpdateAsync(int id, Customers entity)
        {
            throw new NotImplementedException();
        }

    
        Task<ServiceResult<Customers>> IBaseService<Customers>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
