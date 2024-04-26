using JVDev.Entity;
using JVDev.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using JVDev.Data;
using Microsoft.Data.SqlClient;

namespace JVDev.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        protected readonly CoreDbContext dbContext;
        private readonly DbSet<T> dbSet;

        public GenericRepository(CoreDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        public virtual void Add(T entity) =>
            this.dbSet.Add(entity);

        public virtual void AddRange(IEnumerable<T> entities) =>
            this.dbSet.AddRange(entities);

        public virtual void Delete(T entity)
        {
            entity.DELETED = true;
            Update(entity);
        }

        public virtual void DeleteRange(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                entity.DELETED = true;
                Update(entity);
            }
        }

        public virtual void Remove(T entity) =>
            this.dbSet.Remove(entity);

        public virtual void RemoveRange(IEnumerable<T> entities) =>
            this.dbSet.RemoveRange(entities);

        public virtual void Update(T entity) =>
            this.dbSet.Update(entity);

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            dbSet.Where(expression);

        public virtual async Task<IQueryable<T>> GetAllAsync() =>
            await Task.FromResult(dbSet.Where(x => !x.DELETED));

        public virtual async Task<T> GetByUUIDAsync(Guid uuid) =>
            await dbSet.FirstOrDefaultAsync(x => x.UUID == uuid);

        public virtual async Task<T> GetByIdAsync(long id) =>
            await dbSet.FindAsync(id);

        public virtual IQueryable<T> ExecuteSql(string sql, SqlParameter[] sqlParameters) =>
            dbSet.FromSqlRaw(sql, sqlParameters);





    }
}
