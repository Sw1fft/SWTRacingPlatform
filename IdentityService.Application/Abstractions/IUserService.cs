using IdentityService.Application.DTO_s.Request;
using IdentityService.Domain.Models.Base;

namespace IdentityService.Application.Abstractions
{
    public interface IUserService
    {
        Task<BaseResponse> LoginAsync(LoginRequestDto request);
        Task<BaseResponse> RegisterAsync(RegisterRequestDto request);
    }
}
