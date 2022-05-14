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
    public class InvoiceService : BaseService, IBaseService<Invoices>
    {
        public InvoiceService(ServiceContext serviceContext, IServiceManager serviceManager) : base(serviceContext, serviceManager)
        {

        }
        public async Task<ServiceResult<Invoices>> CreateAsync(Invoices entity)
        {
            if (entity == null)
                return new ServiceResult<Invoices>(null, false, "Invoice info is empty!");

            try
            {
                Invoices checkEntity;
                if (entity.Id > 0)
                {
                    checkEntity = await repositoryManager.InvoicesRepository.GetByIDAsync(entity.Id);
                    if (checkEntity != null)
                        return new ServiceResult<Invoices>(null, false, "Invoice already exist!");
                    else
                        entity.Id = 0;
                }

                await repositoryManager.InvoicesRepository.InsertAsync(entity);
                await repositoryManager.CommitAsync();


                return new ServiceResult<Invoices>(entity, true);
            }
            catch (Exception ex)
            {
                return new ServiceResult<Invoices>(null, false, ex.Message);
            }
        }

        public Task<ServiceResult> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<IEnumerable<Invoices>>> GetAsync(Expression<Func<Invoices, bool>> filter = null, Func<IQueryable<Invoices>, IOrderedQueryable<Invoices>> orderBy = null, params Expression<Func<Invoices, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<User>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<IEnumerable<Invoices>>> GetListAsync(FilterCriteria filterCriteria, Expression<Func<Invoices, bool>> predicateQuery = null)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> UpdateAsync(int id, Invoices entity)
        {
            throw new NotImplementedException();
        }

        Task<ServiceResult<Invoices>> IBaseService<Invoices>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
