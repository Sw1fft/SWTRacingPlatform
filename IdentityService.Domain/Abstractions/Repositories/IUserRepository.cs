using IdentityService.Domain.Models;
using IdentityService.Domain.Models.Base;

namespace IdentityService.Domain.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<string> GetUserPasswordHash(string email);
        Task<BaseResponse> CreateUser(User user);
    }
}
