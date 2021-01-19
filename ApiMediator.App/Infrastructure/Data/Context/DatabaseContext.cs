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
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            var entityEntries = ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("UpdateAt") != null) .ToArray();

            foreach (var entry in entityEntries)
            {
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("UpdateAt").CurrentValue = DateTime.Now;
                }
            }
            
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
