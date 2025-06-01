using AutoMapper;
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
        private readonly IMapper _mapper;

        #endregion

        public UserRepository(IPasswordService passwordService, IdentityServiceDbContext dbContext, IMapper mapper)
        {
            _passwordService = passwordService;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<User> GetUser(string email)
        {
            Validate(email);

            UserEntity? entity = await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == email);

            Validate(entity);

            var user = _mapper.Map<User>(entity);

            return user;
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

        private void Validate(UserEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException("Пользователь не найден");
        }

        private void Validate(string email)
        {

        }
    }
}
