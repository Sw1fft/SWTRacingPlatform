using IdentityService.Domain.Models;

namespace IdentityService.Domain.Abstractions.Services
{
    public interface IJwtService
    {
        Task<string> GenerateToken(User user);
    }
}
