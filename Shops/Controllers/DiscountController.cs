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
using Common.Dto.Discount;

namespace Shops.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class DiscountController : BaseController
    {
        readonly IConfiguration configuration;
        public DiscountController(IServiceManager serviceManager, IConfiguration configuration) : base(serviceManager)
        {
            this.configuration = configuration;
        }

        [HttpPost("Create")]
        [AllowAnonymous]
        public async Task<GenericResponse<string>> Create([FromBody] DiscountDto discountDto)
        {
            try
            {
                var discount = mapper.Map<Discount>(discountDto);
                var result = await serviceManager.Discount_Service.CreateAsync(discount);
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
                return GenericResponse<string>.Error(ResultType.Error, "İndirim oluşturulamadı", "", StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("DiscountCalculation")]
        [AllowAnonymous]
        public async Task<GenericResponse<DiscountCalculation>> DiscountCalculation([FromBody] DiscountCalculationDto discountCalculationDto)
        {
            try
            {
                var result = await serviceManager.Discount_Service.DiscountCalculator(discountCalculationDto);
                await serviceManager.CommitAsync();
                DiscountCalculation discountCalculation = new DiscountCalculation();
                discountCalculation.CustomerType = result.CustomerType;
                discountCalculation.DiscountAmount = result.DiscountAmount;
                discountCalculation.DiscountFiveOffForEveryOneHundered = result.DiscountFiveOffForEveryOneHundered;
                discountCalculation.TotarialPayment= result.TotarialPayment;
                discountCalculation.DiscountRate= result.DiscountRate;
                discountCalculation.TotalAmount= result.TotalAmount;
                discountCalculation.CreatedTime = DateTime.Now;
                return GenericResponse<DiscountCalculation>.List(discountCalculation);
            }
            catch (Exception ex)
            {
                return GenericResponse<DiscountCalculation>.Error(ResultType.Error, "İndirim hesaplanamadı", "", StatusCodes.Status500InternalServerError);
            }
        }



    }
}
