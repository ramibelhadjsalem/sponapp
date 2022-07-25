using sponapp.Entities;

namespace sponapp.Data
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {

        Task<IList<TEntity>> GetAll();
        Task<TEntity> Get(string id);

        Task<TEntity> Create(TEntity obj);
        Task<TEntity> Update(TEntity obj);
        Task Delete(string id);
    }
}
