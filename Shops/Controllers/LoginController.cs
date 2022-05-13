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

namespace Shops.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class LoginController : BaseController
    {
        readonly IConfiguration configuration;
        public LoginController(IServiceManager serviceManager, IConfiguration configuration) : base(serviceManager)
        {
            this.configuration = configuration;
        }

        [HttpPost("Create")]
        [AllowAnonymous]
        public async Task<GenericResponse<string>> Create([FromBody] UserDto userDto)
        {
            try
            {
                var user = mapper.Map<User>(userDto);

                var result = await serviceManager.User_Service.CreateAsync(user);

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
                return GenericResponse<string>.Error(ResultType.Error, "Kullanıcı oluşturulamadı", "", StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("GetToken")]
        [AllowAnonymous]
        public async Task<GenericResponse<TokenDto>> GetToken([FromBody] UserLoginDto userLogin)
        {
            try
            {
                var checkUser = await serviceManager.User_Service.GetByEmailAddressAsync(userLogin.Email);

                if (checkUser.Data == null)
                {
                    return GenericResponse<TokenDto>.Error(ResultType.Error, "Kullanıcı bilgileriniz hatalı.", "", StatusCodes.Status500InternalServerError);
                }

                if (!checkUser.Success)
                {
                    return GenericResponse<TokenDto>.Error(ResultType.Error, checkUser.Error, "", StatusCodes.Status500InternalServerError);
                }

                var result = await serviceManager.User_Service.GetToken(checkUser.Data, userLogin.Password, configuration);

                if (result.Success)
                {
                    return GenericResponse<TokenDto>.Ok(result.Data, "");

                }
                else
                {
                    return GenericResponse<TokenDto>.Error(ResultType.Error, result.Error, "", StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<TokenDto>.Error(ResultType.Error, "Kullanıcı bilgileriniz hatalı.", "", StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("Refreshtoken")]
        [AllowAnonymous]
        public async Task<GenericResponse<TokenDto>> Refreshtoken(string refreshToken)
        {
            try
            {
                refreshToken = refreshToken.Replace(" ", "+");
                if (string.IsNullOrEmpty(refreshToken))
                {
                    return GenericResponse<TokenDto>.Error(ResultType.Error, "Değer boş olamaz", "", StatusCodes.Status500InternalServerError);
                }

                var result = await serviceManager.User_Service.RefreshToken(refreshToken, configuration);

                if (result.Success)
                {
                    return GenericResponse<TokenDto>.Ok(result.Data, "");
                }
                else
                {
                    return GenericResponse<TokenDto>.Error(ResultType.Error, result.Error, "", StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<TokenDto>.Error(ResultType.Error, "Kullanıcı bilgileriniz hatalı.", "", StatusCodes.Status500InternalServerError);
            }
        }
    }
}
