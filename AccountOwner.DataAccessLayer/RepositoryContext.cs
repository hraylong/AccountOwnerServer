using AccountOwner.DataAccessLayer.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AccountOwner.DataAccessLayer
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OwnerConfiguration());
        }
    }
}
