using IdentityService.Domain.Entities;
using IdentityService.Infrastructure.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Infrastructure.DataAccess
{
    public class IdentityServiceDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public IdentityServiceDbContext(DbContextOptions<IdentityServiceDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
