using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebPocHub.Dal
{
    public interface ICommonRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetDetails(int id);
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}
