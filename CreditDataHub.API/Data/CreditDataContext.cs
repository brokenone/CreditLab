using Microsoft.EntityFrameworkCore;
using Shared.Core.Entities;

namespace CreditDataHub.API.Data
{
    public class CreditDataContext : DbContext
    {
        public CreditDataContext(DbContextOptions<CreditDataContext> options)
            : base(options) { }

        public DbSet<CustomerProfileEntity> Customers => Set<CustomerProfileEntity>();
    }
}
