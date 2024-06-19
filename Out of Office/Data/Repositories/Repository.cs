using Microsoft.EntityFrameworkCore;
using Out_of_Office.Data.IRepositories;

namespace Out_of_Office.Data.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _dbContext;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task AddAsync(T entity, bool saveChanges)
        {
            await _dbContext.AddAsync(entity);
            if (saveChanges)
                await _dbContext.SaveChangesAsync();
        }

        public virtual async Task AddAsync(IEnumerable<T> entities, bool saveChanges)
        {
            await _dbContext.AddRangeAsync(entities);
            if (saveChanges)
                await _dbContext.SaveChangesAsync();
        }

        public virtual async Task RemoveAsync(T entity, bool saveChanges)
        {
            _dbContext.Remove(entity);
            if (saveChanges)
                await _dbContext.SaveChangesAsync();
        }

        public virtual async Task RemoveAsync(IEnumerable<T> entities, bool saveChanges)
        {
            _dbContext.RemoveRange(entities);
            if (saveChanges)
                await _dbContext.SaveChangesAsync();
        }

        public virtual async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T entity, bool saveChanges)
        {
            _dbContext.Update(entity);
            if (saveChanges)
                await _dbContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(IEnumerable<T> entities, bool saveChanges)
        {
            _dbContext.UpdateRange(entities);
            if (saveChanges)
                await _dbContext.SaveChangesAsync();
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

    }
}
