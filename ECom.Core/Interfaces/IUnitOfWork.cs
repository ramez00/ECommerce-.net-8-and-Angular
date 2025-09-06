using ECom.Core.Entities;

namespace ECom.Core.Interfaces;
public interface IUnitOfWork
{
    public IRepositry<Product> ProductRepositry { get; }
    public IRepositry<Category> CategoryRepositry { get; }
    public IRepositry<Photo> PhotoRepositry { get; }
}
