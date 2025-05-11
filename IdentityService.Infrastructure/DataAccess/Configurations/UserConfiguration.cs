using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityService.Infrastructure.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserConfiguration>
    {
        public void Configure(EntityTypeBuilder<UserConfiguration> builder)
        {
            throw new NotImplementedException();
        }
    }
}
