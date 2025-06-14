using AccountService.Domain.Models;

namespace AccountService.Domain.Abstractions.Repositories
{
    public interface IHeaderRepository
    {
        Task<HeaderContentData> GetHeaderData();
    }
}
