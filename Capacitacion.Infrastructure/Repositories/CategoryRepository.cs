using Capacitacion.Domain.Categories;
using Microsoft.EntityFrameworkCore;

namespace Capacitacion.Infrastructure.Repositories;

internal sealed class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(CapacitacionDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Category>> GetAll(CancellationToken cancellationToken)
    {
       return await (
                    from c in dbContext.Set<Category>()
                    select c
                    ).ToListAsync(cancellationToken);
    }
}