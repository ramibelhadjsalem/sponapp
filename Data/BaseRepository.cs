using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using sponapp.Entities;

namespace sponapp.Data
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DataContext _context;

        public BaseRepository(DataContext Context)
        {
            _context = Context;
        }

        public async Task<TEntity> Create(TEntity obj)
        {
            EntityEntry<TEntity> newObj = await _context.Set<TEntity>().AddAsync(obj);
            newObj.Entity.UpdatedAt = DateTime.Now.ToUniversalTime();   
            await _context.SaveChangesAsync();
            return newObj.Entity;

        }

        public async Task Delete(string id)
        {
            TEntity obj = await _context.Set<TEntity>().FirstOrDefaultAsync();
            if(obj != null)
            {
                obj.DeletedAt = DateTime.Now.ToUniversalTime();
                obj.Enable = false;
                
                await _context.SaveChangesAsync();
            }
        }

        public async Task<TEntity> Get(string id)
        {
            TEntity? entity = await _context.Set<TEntity>()
                             .Where(x => x.Enable)
                             .FirstOrDefaultAsync();
            return entity;
        }

        public async Task<IList<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>()
                             .Where(x => x.Enable)
                             .ToListAsync();
        }

        public async Task<TEntity> Update(TEntity obj)
        {
            EntityEntry<TEntity> newObj = _context.Set<TEntity>().Update(obj);
            newObj.Entity.UpdatedAt = DateTime.Now.ToUniversalTime();
            await _context.SaveChangesAsync();
            return newObj.Entity;
        }
    }
}
