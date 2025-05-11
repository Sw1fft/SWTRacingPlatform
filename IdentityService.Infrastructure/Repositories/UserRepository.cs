using IdentityService.Domain.Abstractions.Repositories;
using IdentityService.Domain.Abstractions.Services;
using IdentityService.Domain.Entities;
using IdentityService.Domain.Models;
using IdentityService.Domain.Models.Base;
using IdentityService.Infrastructure.DataAccess;
using IdentityService.Infrastructure.Services.Base;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Infrastructure.Repositories
{
    public class UserRepository : BaseService, IUserRepository
    {
        #region private

        private readonly IPasswordService _passwordService;
        private readonly IdentityServiceDbContext _dbContext;

        #endregion

        public UserRepository(IPasswordService passwordService, IdentityServiceDbContext dbContext)
        {
            _passwordService = passwordService;
            _dbContext = dbContext;
        }

        public async Task<string> GetUserPasswordHash(string email)
        {
            var entity = await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == email)
                ?? throw new NullReferenceException("Пользователя с таким email не существует");

            return entity.PasswordHash;
        }

        public async Task<BaseResponse> CreateUser(User user)
        {
            // Добавить проверку на существующего пользователя

            var hash = await _passwordService.GeneratePassword(user.Password);

            var entity = new UserEntity()
            {
                Id = Guid.NewGuid(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Email = user.Email,
                Phone = user.Phone,
                PasswordHash = hash
            };

            await _dbContext.Users.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return await GetSuccessResult(DateTime.Now.ToString(), "Регистрация выполнена успешно");
        }
    }
}
