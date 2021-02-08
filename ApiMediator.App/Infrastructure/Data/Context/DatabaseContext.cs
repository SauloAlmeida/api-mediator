using ApiMediator.App.Domain.Product.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiMediator.App.Infrastructure.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            var entries = ChangeTracker.Entries()
                         .Where(w => w.State == EntityState.Modified)
                         .Where(entry => entry.Entity.GetType().GetProperty(Constant.Data.UPDATED_AT) != null)
                         .ToArray();

            foreach (var entry in entries)
            {
                entry.Property(Constant.Data.UPDATED_AT).CurrentValue = DateTime.Now;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
