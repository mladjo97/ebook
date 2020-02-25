namespace EBook.Persistence.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRepositoryBase<TPKey, TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get(TPKey primaryKey);
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TPKey primaryKey, TEntity entity);
        Task<TPKey> Delete(TPKey primaryKey);
    }
}
