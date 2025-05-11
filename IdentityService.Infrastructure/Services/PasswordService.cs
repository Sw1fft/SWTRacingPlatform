using IdentityService.Domain.Abstractions.Services;

namespace IdentityService.Infrastructure.Services
{
    public class PasswordService : IPasswordService
    {
        public Task<bool> CompairPassword(string password, string passwordConf)
        {
            if (password != passwordConf)
                return Task.FromResult(false);

            return Task.FromResult(true);
        }

        public Task<string> GeneratePassword(string password)
        {
            string result = BCrypt.Net.BCrypt.EnhancedHashPassword(password);

            return Task.FromResult(result);
        }

        public Task<bool> VerifyPassword(string password, string hasedPassword)
        {
            bool result = BCrypt.Net.BCrypt.EnhancedVerify(password, hasedPassword);

            return Task.FromResult(result);
        }
    }
}
