using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IDisposable
    {

        public Context context { get; internal set; }

        public RepositoryManager()
        {
            this.context = new Context();
        }

        public RepositoryManager(Context db)
        {
            this.context = db;
        }


        #region User
        private UserRepository userRepository;
        public UserRepository UserRepository
        {
            get
            {
                this.userRepository = this.userRepository ?? new UserRepository(context);
                return this.userRepository;
            }
        }
        #endregion
        #region UserRole
        private UserRoleRepository userRoleRepository;
        public UserRoleRepository UserRoleRepository
        {
            get
            {
                this.userRoleRepository = this.userRoleRepository ?? new UserRoleRepository(context);
                return this.userRoleRepository;
            }
        }
        #endregion
        #region Role
        private RoleRepository roleRepository;
        public RoleRepository RoleRepository
        {
            get
            {
                this.roleRepository = this.roleRepository ?? new RoleRepository(context);
                return this.roleRepository;
            }
        }
        #endregion
        #region CustomerRole
        private CustomerRoleRepository customerRoleRepository;
        public CustomerRoleRepository CustomerRoleRepository
        {
            get
            {
                this.customerRoleRepository = this.customerRoleRepository ?? new CustomerRoleRepository(context);
                return this.customerRoleRepository;
            }
        }
        #endregion
        #region Customers
        private CustomersRepository customersRepository;
        public CustomersRepository CustomersRepository
        {
            get
            {
                this.customersRepository = this.customersRepository ?? new CustomersRepository(context);
                return this.customersRepository;
            }
        }
        #endregion
        #region Discount
        private DiscountRepository discountRepository;
        public DiscountRepository DiscountRepository
        {
            get
            {
                this.discountRepository = this.discountRepository ?? new DiscountRepository(context);
                return this.discountRepository;
            }
        }
        #endregion
        #region Invoices
        private InvoicesRepository invoicesRepository;
        public InvoicesRepository InvoicesRepository
        {
            get
            {
                this.invoicesRepository = this.invoicesRepository ?? new InvoicesRepository(context);
                return this.invoicesRepository;
            }
        }
        #endregion
      


        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
