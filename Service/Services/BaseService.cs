using AutoMapper;
using Common;
using Microsoft.Extensions.Configuration;
using Repository;

namespace Service.Services
{
    public class BaseService
    {
        protected readonly IMapper mapper;
        protected readonly Context context;
        protected readonly ServiceContext serviceContext;
        protected readonly RepositoryManager repositoryManager;
        protected readonly IServiceManager serviceManager;

        public BaseService(ServiceContext serviceContext, IServiceManager serviceManager)
        {
            this.serviceContext = serviceContext;
            this.mapper = serviceContext.GetItem<IMapper>("IMapper");
            this.context = serviceContext.GetItem<Context>("DbContext");
            this.repositoryManager = new RepositoryManager(this.context);
            this.serviceManager = serviceManager;
        }
    }
}
