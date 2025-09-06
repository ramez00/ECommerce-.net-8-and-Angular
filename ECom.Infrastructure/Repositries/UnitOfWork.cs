using ECom.Core.Interfaces;
using ECom.Infrastructure.Data;

namespace ECom.Infrastructure.Repositries;
public class UnitOfWork(ApplicationDbContext dbContext) : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    public IRepositry<Product> ProductRepositry => new Repostry<Product>(_dbContext);

    public IRepositry<Category> CategoryRepositry => new Repostry<Category>(_dbContext);

    public IRepositry<Photo> PhotoRepositry => new Repostry<Photo>(_dbContext);
}
