using Capacitacion.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Capacitacion.Infrastructure.Repositories;

internal sealed class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(CapacitacionDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Product>> GetAll(CancellationToken cancellationToken)
    {
       return await dbContext.Set<Product>().ToListAsync(cancellationToken);
    }

    public async Task<Product?> GetByCode(string code, CancellationToken cancellationToken)
    {
       return await dbContext
                    .Set<Product>()
                    .Where(x => x.Code == code)
                    .FirstOrDefaultAsync(cancellationToken);
    }
}
