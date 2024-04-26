using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace JVDev.Data
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
