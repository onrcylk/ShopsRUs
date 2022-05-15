using AutoMapper;
using Common;
using Microsoft.AspNetCore.Http;
using Repository;
using Service.Services;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager : IServiceManager, IDisposable
    {
        public ServiceContext serviceContext { get; internal set; }
        private RepositoryManager repositoryManager;

        public ServiceManager(Context context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            serviceContext = new ServiceContext();
            serviceContext.AddItem("DbContext", context);
            serviceContext.AddItem("IHttpContextAccessor", httpContextAccessor);
            serviceContext.AddItem("IMapper", mapper);

            repositoryManager = new RepositoryManager(context);
        }

        public async Task CommitAsync()
        {
            try
            {
                await repositoryManager.CommitAsync();
            }
            catch (Exception e)
            {
                //Log.Exception(e);
                throw e;
            }
        }

        #region Disposing
        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (serviceContext != null)
                    {
                        //_log.Debug("ServiceContext is being disposed");
                        serviceContext.Dispose();
                    }
                }
                disposed = true;
            }
        }
        ~ServiceManager()
        {
            Dispose(false);
        }
        #endregion
        
      

        #region User
        private UserService userService;
        UserService IServiceManager.User_Service
        {
            get
            {
                if (this.userService == null)
                    userService = new UserService(serviceContext, this);

                return userService;
            }
        }
        #endregion
        #region Invoice
        private InvoiceService invoiceService;
        InvoiceService IServiceManager.Invoice_Service
        {
            get
            {
                if (this.invoiceService == null)
                    invoiceService = new InvoiceService(serviceContext, this);

                return invoiceService;
            }
        }
        #endregion
        #region Customers
        private CustomerService customersService;
        CustomerService IServiceManager.Customer_Service
        {
            get
            {
                if (this.customersService == null)
                    customersService = new CustomerService(serviceContext, this);

                return customersService;
            }
        }
        #endregion
        #region Discount
        private DiscountService discountService;
        DiscountService IServiceManager.Discount_Service
        {
            get
            {
                if (this.discountService == null)
                    discountService = new DiscountService(serviceContext, this);

                return discountService;
            }
        }
        #endregion


    }
}
