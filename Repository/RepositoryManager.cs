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
