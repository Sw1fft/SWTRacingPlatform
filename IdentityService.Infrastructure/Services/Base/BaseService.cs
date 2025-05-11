using IdentityService.Domain.Models.Base;

namespace IdentityService.Infrastructure.Services.Base
{
    public class BaseService
    {
        public Task<BaseResponse> GetSuccessResult(string time, string message)
        {
            return Task.FromResult(new BaseResponse()
            {
                Time = time,
                Message = message,
                Status = true
            });
        }

        public Task<BaseResponse> GetBadResult(string time, string message)
        {
            return Task.FromResult(new BaseResponse()
            {
                Time = time,
                Message = message,
                Status = false
            });
        }
    }
}
