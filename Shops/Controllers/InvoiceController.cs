﻿using Common.Dto.Token;
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

namespace Shops.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class InvoiceController : BaseController
    {
        readonly IConfiguration configuration;
        public InvoiceController(IServiceManager serviceManager, IConfiguration configuration) : base(serviceManager)
        {
            this.configuration = configuration;
        }

        [HttpPost("Create")]
        [AllowAnonymous]
        public async Task<GenericResponse<string>> Create([FromBody] InvoiceDto ınvoiceDto)
        {
            try
            {
                var invoice = mapper.Map<Invoices>(ınvoiceDto);

                var result = await serviceManager.Invoice_Service.DiscountInvoiceCreateAsync(invoice);

                if (result.Success)
                {
                    //return result.Data.Discount.DiscountName; 
                    return GenericResponse<string>.Ok();
                }
                else
                {
                    return GenericResponse<string>.Error(ResultType.Error, result.Error, "", StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<string>.Error(ResultType.Error, "Fatura oluşturulamadı", "", StatusCodes.Status500InternalServerError);
            }
        }

      
    }
}