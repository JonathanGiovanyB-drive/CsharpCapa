using Capacitacion.Domain.Categories.Events;

namespace Capacitacion.Domain.Categories;

public interface ICategoryRepository
{
    Task<List<Category>> GetAll(CancellationToken cancellationToken);
    void Add(Category category);
    Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}