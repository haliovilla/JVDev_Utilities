namespace JVDev.Repository
{
    public interface ICoreUnitOfWork : IDisposable
    {
        Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
