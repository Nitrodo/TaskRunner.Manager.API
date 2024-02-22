using System.Linq.Expressions;

namespace TaskRunner.Manager.Infrastructure.Persitence.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Find(Expression<Func<TEntity, bool>> filter);
        void Insert(TEntity entity);
        void SaveChanges();
    }
}
