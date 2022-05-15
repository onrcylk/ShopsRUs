using Common;
using Common.Dto.Token;
using Common.Dto.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using NPOI.SS.Formula.Functions;
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

        public async Task<ServiceResult<Invoices>> DiscountInvoiceCreateAsync(Invoices entity)
        {
            if (entity == null)
                return new ServiceResult<Invoices>(null, false, "Invoice info is empty!");

            try
            {
                var statu = repositoryManager.CustomersRepository.GetByEmailAddressAsync(entity.CustomerEmail).Result.CustomerStatu;
                //Customer 
                if (statu == 3)
                {
                    DateTime registerTime = repositoryManager.CustomersRepository.GetByEmailAddressAsync(entity.CustomerEmail).Result.CreatedTime;
                    TimeSpan discountCustomer = DateTime.Now - registerTime;
                    if (discountCustomer.TotalDays < 730)
                    {
                        entity.TotalAmount = entity.UnitPrice * entity.Quantity;
                        if (entity.TotalAmount < 100)
                        {
                            entity.DiscountAmount = 0;
                            entity.TotarialPayment = entity.TotalAmount;
                            await repositoryManager.InvoicesRepository.InsertAsync(entity);
                            await repositoryManager.CommitAsync();
                            return new ServiceResult<Invoices>(entity, true);
                        }
                        else
                        {
                            double iDiscount = Math.Floor(entity.TotalAmount / 100) * 5;
                            double newTotalAmount = entity.TotalAmount - iDiscount;
                            entity.DiscountAmount = 0;
                            entity.TotarialPayment = newTotalAmount;
                            await repositoryManager.InvoicesRepository.InsertAsync(entity);
                            await repositoryManager.CommitAsync();
                            return new ServiceResult<Invoices>(entity, true);
                        }
                    }
                }
                var discountRate = repositoryManager.DiscountRepository.GetByDiscount(statu).Result.Rate;

                entity.TotalAmount = entity.UnitPrice * entity.Quantity;
                if (entity.TotalAmount < 100)
                {
                    entity.DiscountAmount = (entity.TotalAmount * discountRate) / 100;
                    entity.TotarialPayment = entity.TotalAmount - entity.DiscountAmount;
                }
                else
                {
                    //Faturadakı her 100 abd doları ıcın 5 dolar ındırım
                    double iDiscount = Math.Floor(entity.TotalAmount / 100) * 5;
                    double newTotalAmount = entity.TotalAmount - iDiscount;
                    entity.DiscountAmount = (newTotalAmount * discountRate) / 100;
                    entity.TotarialPayment = newTotalAmount - entity.DiscountAmount;
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
        public async Task<ServiceResult<List<Invoices>>> GetListInvoiceAsync()
        {
            ServiceResult<List<Invoices>> resultList = null;
            resultList = new ServiceResult<List<Invoices>>(await repositoryManager.InvoicesRepository.GetInvoiceList(), true, "", null);
            return new ServiceResult<List<Invoices>>(resultList.Data, true, "", resultList.paging);
        }

        public async Task<ServiceResult<IEnumerable<Invoices>>> GetListAsync(FilterCriteria filterCriteria, Expression<Func<Invoices, bool>> predicateQuery = null)
        {
            ServiceResult<IEnumerable<Invoices>> resultList = null;
            resultList = new ServiceResult<IEnumerable<Invoices>>(await repositoryManager.InvoicesRepository.FindAsync(filterCriteria, predicateQuery), true, pagingFilter: filterCriteria.PagingFilter);
            if (resultList.Success)
            {
                return new ServiceResult<IEnumerable<Invoices>>(resultList.Data, true, "", resultList.paging);
            }
            else
            {
                return new ServiceResult<IEnumerable<Invoices>>(null, false, resultList.Error);
            }
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
