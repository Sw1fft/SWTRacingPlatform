using AccountService.Domain.Abstractions.Repositories;
using AccountService.Domain.Abstractions.Services;
using AccountService.Domain.Models;

namespace AccountService.Infrastructure.Services
{
    public class HeaderService : IHeaderService
    {
        #region private
        private readonly IHeaderRepository _headerRepository;
        #endregion

        public HeaderService(IHeaderRepository headerRepository)
        {
            _headerRepository = headerRepository;
        }

        public Task<HeaderContentData> GetPublicHeaderData()
        {
            throw new NotImplementedException();
        }

        public async Task<HeaderContentData> GetPrivateHeaderData()
        {
            var result = await _headerRepository.GetHeaderData();

            return result;
        }
    }
}
