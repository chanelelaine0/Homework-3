using Microsoft.EntityFrameworkCore;
using SPA.Domain.Core;
using  SPA.Infrastructure.Context;

namespace SPA.Infrastructure.Core
{
    public class BaseRepository<T> where T : BaseEntity
    {
        protected readonly SpaContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(SpaContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
        public virtual async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
        public virtual async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public virtual async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return;
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
