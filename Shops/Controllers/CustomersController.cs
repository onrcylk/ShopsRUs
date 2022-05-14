using Common.Dto.Token;
using Common.Dto.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Repository.Entities;
using Service;
using Shops.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shops.Helper;
using Common.Dto.Invoice;
using Common.Dto.Customers;

namespace Shops.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class CustomersController : BaseController
    {
        readonly IConfiguration configuration;
        public CustomersController(IServiceManager serviceManager, IConfiguration configuration) : base(serviceManager)
        {
            this.configuration = configuration;
        }

        [HttpPost("Create")]
        [AllowAnonymous]
        public async Task<GenericResponse<string>> Create([FromBody] CustomersDto customersDto)
        {
            try
            {
                Customers customers = new Customers()
                {
                    CreatedTime = DateTime.Now,
                    CustomerRoleId = customersDto.CustomerRoleId,
                    Email = customersDto.Email,
                    isDeleted = false,
                    Name=customersDto.Name,
                    Password=customersDto.Password,
                    Surname=customersDto.Surname,
                };

                var result = await serviceManager.Customer_Service.CreateAsync(customers);

                if (result.Success)
                {
                    return GenericResponse<string>.Ok();
                }
                else
                {
                    return GenericResponse<string>.Error(ResultType.Error, result.Error, "", StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<string>.Error(ResultType.Error, "Müşteri oluşturulamadı", "", StatusCodes.Status500InternalServerError);
            }
        }

      
    }
}
