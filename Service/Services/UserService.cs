using Common;
using Common.Dto.Token;
using Common.Dto.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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
    public class UserService : BaseService, IBaseService<User>
    {
        protected readonly PasswordHasher<User> passwordHasher;
        public UserService(ServiceContext serviceContext, IServiceManager serviceManager) : base(serviceContext, serviceManager)
        {
            passwordHasher = new PasswordHasher<User>();

        }
        public async Task<ServiceResult<User>> CreateAsync(User entity)
        {
            if (entity == null)
                return new ServiceResult<User>(null, false, "User info is empty!");

            try
            {
                User checkEntity;
                if (entity.Id > 0)
                {
                    checkEntity = await repositoryManager.UserRepository.GetByIDAsync(entity.Id);
                    if (checkEntity != null)
                        return new ServiceResult<User>(null, false, "User already exist!");
                    else
                        entity.Id = 0;
                }
                if (!string.IsNullOrEmpty(entity.Password))
                    entity.Password = passwordHasher.HashPassword(entity, entity.Password);

                checkEntity = await repositoryManager.UserRepository.GetByEmailAddressAsync(entity.Email);
                if (checkEntity != null)
                    return new ServiceResult<User>(null, false, "Email address already exist!");

                await repositoryManager.UserRepository.InsertAsync(entity);
                await repositoryManager.CommitAsync();


                return new ServiceResult<User>(entity, true);
            }
            catch (Exception ex)
            {
                return new ServiceResult<User>(null, false, ex.Message);
            }
        }

        public Task<ServiceResult> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<IEnumerable<User>>> GetAsync(Expression<Func<User, bool>> filter = null, Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null, params Expression<Func<User, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<TokenDto>> GetToken(User user, string password, IConfiguration configuration)
        {
            try
            {
                var pass = passwordHasher.VerifyHashedPassword(user, user.Password, password);

                if (pass.ToString() == "Success")
                {
                    TokenHandler tokenHandler = new TokenHandler(configuration);
                    TokenDto tokenDto = tokenHandler.CreateAccessToken(user);

                    user.RefreshToken = tokenDto.RefreshToken;
                    user.RefreshTokenEndDate = tokenDto.Expiration.AddMinutes(3);
                    await repositoryManager.UserRepository.UpdateAsync(user.Id, user);
                    await repositoryManager.CommitAsync();

                    return new ServiceResult<TokenDto>(tokenDto, true);
                }
                else
                {
                    return new ServiceResult<TokenDto>(null, false);
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult<TokenDto>(null, false, ex.Message);
            }
        }

        public async Task<ServiceResult<User>> GetByToken(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);

                var entity = await repositoryManager.UserRepository.GetByIDAsync(Convert.ToInt32(jwtToken.Claims.FirstOrDefault(w => w.Type == "userId").Value));
                if (entity != null)
                {

                    return new ServiceResult<User>(entity, true);
                }
                else
                    return new ServiceResult<User>(null, false, "User not found!");

            }
            catch (Exception ex)
            {
                return new ServiceResult<User>(null, false, ex.Message);

            }

        }

        public async Task<ServiceResult<TokenDto>> RefreshToken(string refreshToken, IConfiguration configuration)
        {
            try
            {
                var user = await repositoryManager.UserRepository.GetByRefreshTokenAsync(refreshToken);

                if (user != null && user?.RefreshTokenEndDate > DateTime.Now)
                {
                    TokenHandler tokenHandler = new TokenHandler(configuration);
                    TokenDto tokenDto = tokenHandler.CreateAccessToken(user);

                    user.RefreshToken = tokenDto.RefreshToken;
                    user.RefreshTokenEndDate = tokenDto.Expiration.AddMinutes(3);
                    await repositoryManager.UserRepository.UpdateAsync(user.Id, user);
                    await repositoryManager.CommitAsync();
                    return new ServiceResult<TokenDto>(tokenDto, true);
                }
                else
                {
                    return new ServiceResult<TokenDto>(null, false);
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult<TokenDto>(null, false, ex.Message);
            }
        }

        public Task<ServiceResult<User>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<IEnumerable<User>>> GetListAsync(FilterCriteria filterCriteria, Expression<Func<User, bool>> predicateQuery = null)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> UpdateAsync(int id, User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<User>> GetByEmailAddressAsync(string email)
        {
            try
            {
                User data = await repositoryManager.UserRepository.GetByEmailAddressAsync(email);

                return new ServiceResult<User>(data, true);
            }
            catch (Exception ex)
            {
                return new ServiceResult<User>(null, false, ex.Message);
            }
        }

    }
}
