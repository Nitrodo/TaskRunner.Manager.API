using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskRunner.Manager.Infrastructure.Persitence.Interfaces;


namespace TaskRunner.Manager.Infrastructure.Persitence
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        /// <summary>
        /// Retrieve an entity.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>TEntity</returns>
        public TEntity Get(int id)
        {
            return _dbSet.Find(id);
        }

        /// <summary>
        /// Find an entity with include members.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includeMembers"></param>
        /// <returns></returns>
        public TEntity Find(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeMembers)
        {
            IQueryable<TEntity> query;

            if (includeMembers != null)
                query = includeMembers(_dbSet);
            else
                query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.FirstOrDefault();
        }

        /// <summary>
        /// Find an entity.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includeMembers"></param>
        /// <returns></returns>
        public TEntity Find(Expression<Func<TEntity, bool>> filter)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.FirstOrDefault();
        }

        /// <summary>
        /// Get all values for an entity.
        /// </summary>
        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet;
        }

        /// <summary>
        /// Get all values for an entity with include members.
        /// </summary>
        public IEnumerable<TEntity> GetAll(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeMembers)
        {
            IQueryable<TEntity> query;

            if (includeMembers != null)
                query = includeMembers(_dbSet);
            else
                query = _dbSet;


            return query;
        }

        /// <summary>
        /// Insert a new entity.
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        /// <summary>
        /// Insert new entities.
        /// </summary>
        /// <param name="entity"></param>
        public void InsertMany(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        /// <summary>
        /// Save all changes.
        /// </summary>
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
