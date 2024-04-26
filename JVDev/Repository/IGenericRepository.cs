using JVDev.Entity;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace JVDev.Repository
{
    public interface IGenericRepository<T> where T : EntityBase
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T entity);

        Task<T> GetByIdAsync(long id);
        Task<T> GetByUUIDAsync(Guid uuid);
        Task<IQueryable<T>> GetAllAsync();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        IQueryable<T> ExecuteSql(string sql, SqlParameter[] sqlParameters);
    }
}
