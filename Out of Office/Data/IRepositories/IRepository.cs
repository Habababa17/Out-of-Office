using Microsoft.EntityFrameworkCore;
using Out_of_Office.Models.DB_Models;

namespace Out_of_Office.Data.IRepositories
{
    public interface IRepository<T> where T : class
    {
        public Task AddAsync(T entity, bool saveChanges = true);
        public Task AddAsync(IEnumerable<T> entites, bool saveChanges = true);
        public Task RemoveAsync(T entity, bool saveChanges = true);
        public Task RemoveAsync(IEnumerable<T> entities, bool saveChanges = true);
        public Task UpdateAsync(T entity, bool saveChanges = true);
        public Task UpdateAsync(IEnumerable<T> entities, bool saveChanges = true);
        public Task SaveChangesAsync();
        public Task<IEnumerable<T>> GetAllAsync();
    }
}
