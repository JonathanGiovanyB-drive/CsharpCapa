using Capacitacion.Domain.Roles;
using Capacitacion.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Capacitacion.Infrastructure.Repositories;

internal sealed class RolRepository : Repository<Rol>, IRolRepository
{
    public RolRepository(CapacitacionDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Rol>> GetAll(CancellationToken cancellationToken)
    {
        return await (
            from c in dbContext.Set<Rol>()
            select c
            ).ToListAsync(cancellationToken);
    }
}