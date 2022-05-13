using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shops.Controllers
{  
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMapper mapper;
        protected readonly IServiceManager serviceManager;
        protected readonly long currentUserId;

        protected BaseController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
            this.mapper = this.serviceManager.serviceContext.GetItem<IMapper>("IMapper");
        }

    }
}
