using System.Collections.Generic;
using System.Linq;

namespace grfcTest.DataLayer.Infrastructure
{
    public interface IEntityRepository<in TEntityInterface> where TEntityInterface : class
    {
        IQueryable<TEntity> GetTable<TEntity>() where TEntity : class, TEntityInterface;
        void InsertOnSave<TEntity>(TEntity entity) where TEntity : class, TEntityInterface;
        void InsertRangeOnSave<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, TEntityInterface;
        void DeleteOnSave<TEntity>(TEntity entity) where TEntity : class, TEntityInterface;
        void DeleteRangeOnSave<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, TEntityInterface;
        void SaveChanges();
    }
}