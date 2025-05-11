using IdentityService.Application.DTO_s.Request;
using IdentityService.Domain.Models.Base;

namespace IdentityService.Domain.Abstractions.Services
{
    public interface IUserService
    {
        Task<BaseResponse> LoginAsync(LoginRequestDto request);
        Task<BaseResponse> RegisterAsync(RegisterRequestDto request);
    }
}
