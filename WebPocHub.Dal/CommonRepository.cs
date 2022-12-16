using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebPocHub.Dal
{
    public class CommonRepository<T> : ICommonRepository<T> where T : class
    {
        private readonly WebPocHubDbContext _dbContext;

        public CommonRepository(WebPocHubDbContext context)
        {
            _dbContext = context;
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetDetails(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> Insert(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);

            if (entity == null)
            {
                return entity;
            }

            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
