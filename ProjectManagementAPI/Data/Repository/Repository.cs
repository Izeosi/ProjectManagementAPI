using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ProjectManagementAPI.Data.Repository
{
    public class Repository<T>: IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<List<T>> GetAllAsync(bool useNoTracking = false)
        {
            IQueryable<T> query = _dbSet;
            if (useNoTracking)
            {
                query = query.AsNoTracking();
            }
            return await query.ToListAsync();
        }

        public async Task<List<T>> GetByAnyFilterAsync(Expression<Func<T, bool>> filter, bool useNoTracking = false)
        {
            IQueryable<T> query = _dbSet;
            if (useNoTracking)
            {
                query = query.AsNoTracking();
            }
            return await query.Where(filter).ToListAsync();
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter, bool useNoTracking = false)
        {
            IQueryable<T> query = _dbSet;
            if (useNoTracking)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(filter);
        }

        public async Task<T> CreateAsync(T dbRecord)
        {
            await _dbSet.AddAsync(dbRecord);
            await _dbContext.SaveChangesAsync();
            return dbRecord;
        }

        public async Task<T?> UpdateAsync(T dbRecord)
        {
            var entityType = _dbContext.Model.FindEntityType(typeof(T))
                ?? throw new InvalidOperationException(
                    $"Entity type {typeof(T).Name} is not part of the EF Core model.");

            var key = entityType.FindPrimaryKey()
                ?? throw new InvalidOperationException(
                    $"Entity type {typeof(T).Name} has no primary key.");

            var keyValues = key.Properties
                .Select(property =>
                    property.PropertyInfo?.GetValue(dbRecord)
                    ?? throw new InvalidOperationException(
                        $"Could not read key property {property.Name}."))
                .ToArray();

            var existingRecord = await _dbSet.FindAsync(keyValues);

            if (existingRecord == null)
            {
                return null;
            }

            _dbContext.Entry(existingRecord).CurrentValues.SetValues(dbRecord);
            await _dbContext.SaveChangesAsync();

            return existingRecord;
        }

        public async Task<bool> DeleteAsync(T dbRecord)
        {
            var entityType = _dbContext.Model.FindEntityType(typeof(T))
                ?? throw new InvalidOperationException(
                    $"Entity type {typeof(T).Name} is not part of the EF Core model.");

            var key = entityType.FindPrimaryKey()
                ?? throw new InvalidOperationException(
                    $"Entity type {typeof(T).Name} has no primary key.");

            var keyValues = key.Properties
                .Select(property =>
                    property.PropertyInfo?.GetValue(dbRecord)
                    ?? throw new InvalidOperationException(
                        $"Could not read key property {property.Name}."))
                .ToArray();

            var existingRecord = await _dbSet.FindAsync(keyValues);

            if (existingRecord == null)
            {
                return false;
            }

            _dbSet.Remove(existingRecord);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}