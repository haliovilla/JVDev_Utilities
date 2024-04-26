using JVDev.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using JVDev.Entity;
using JVDev.Extensions;

namespace JVDev.Repository
{
    public abstract class CoreUnitOfWork : ICoreUnitOfWork
    {
        private readonly CoreDbContext dbContext;

        public CoreUnitOfWork(CoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public virtual async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            (from e in dbContext.ChangeTracker.Entries()
         where e.Entity is EntityBase && (e.State == EntityState.Added || e.State == EntityState.Modified)
         select e).ToList().ForEach(delegate (EntityEntry entityEntry)
         {
             if (entityEntry.State == EntityState.Added)
             {
                 ((EntityBase)entityEntry.Entity).CREATED = new DateTime().GetTimeByTimeZone();
             }

         ((EntityBase)entityEntry.Entity).UPDATED = new DateTime().GetTimeByTimeZone();
         });
            return await dbContext.SaveChangesAsync(cancellationToken) > 0;
        }


        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
