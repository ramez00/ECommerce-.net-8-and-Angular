using ECom.Core.Interfaces;
using ECom.Infrastructure.Data;

namespace ECom.Infrastructure.Repositries;
public class Repostry<T>(ApplicationDbContext dbContext) : IRepositry<T> where T : class
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = _dbContext.Set<T>().Find(id);
        if (entity is not null)
        {
            _dbContext.Set<T>().Remove(entity);
            await SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<T>> GetAllAsync()
        => await _dbContext.Set<T>().AsNoTracking().ToListAsync();

    public async Task<IEnumerable<T>> GetAllAsync(params System.Linq.Expressions.Expression<Func<T, object>>[] expressions)
    {
        var query = _dbContext.Set<T>().AsNoTracking().AsQueryable();

        foreach (var expression in expressions)
            query = query.Include(expression);
        
       return await query.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
        => await _dbContext.Set<T>().FindAsync(id);

    public async Task<T?> GetByIdAsync(int id, params System.Linq.Expressions.Expression<Func<T, object>>[] expressions)
    {
        var query = _dbContext.Set<T>().AsQueryable();

        foreach (var expression in expressions)
            query = query.Include(expression);

        return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
    }

    public async Task SaveChangesAsync()
        => await _dbContext.SaveChangesAsync();

    public Task UpdateAsync(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        return SaveChangesAsync();
    }
}
