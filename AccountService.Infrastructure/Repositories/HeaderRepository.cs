using AccountService.Domain.Abstractions.Repositories;
using AccountService.Domain.Models;

namespace AccountService.Infrastructure.Repositories
{
    public class HeaderRepository : IHeaderRepository
    {
        #region private

        #endregion

        public HeaderRepository()
        {
            
        }

        public Task<HeaderContentData> GetHeaderData()
        {
            throw new NotImplementedException();
        }
    }
}
