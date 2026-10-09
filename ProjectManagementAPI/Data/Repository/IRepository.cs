using System.Linq.Expressions;

namespace ProjectManagementAPI.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(bool useNoTracking = false);
        Task<List<T>> GetByAnyFilterAsync(Expression<Func<T, bool>> filter, bool useNoTracking = false);
        Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter, bool useNoTracking = false);
        Task<T> CreateAsync(T dbRecord);
        Task<T?> UpdateAsync(T dbRecord);
        Task<bool> DeleteAsync(T dbRecord);
    }
}
