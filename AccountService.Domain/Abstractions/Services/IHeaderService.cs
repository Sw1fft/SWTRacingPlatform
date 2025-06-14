using AccountService.Domain.Models;

namespace AccountService.Domain.Abstractions.Services
{
    public interface IHeaderService
    {
        Task<HeaderContentData> GetPublicHeaderData();
        Task<HeaderContentData> GetPrivateHeaderData();
    }
}
