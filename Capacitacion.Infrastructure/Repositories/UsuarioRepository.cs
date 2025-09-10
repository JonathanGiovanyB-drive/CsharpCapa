

using Capacitacion.Domain.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace Capacitacion.Infrastructure.Repositories;


internal sealed class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(CapacitacionDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Usuario>> GetAll(CancellationToken cancellationToken)
    {
        return await dbContext.Set<Usuario>().ToListAsync(cancellationToken);       
    }

   public async Task<Usuario?> GetByCode(string id, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(id, out Guid guidId))
        {
            return null; // También puedes lanzar una excepción si prefieres manejarlo explícitamente
        }

        return await dbContext.Set<Usuario>()
            .FirstOrDefaultAsync(x => x.Id == guidId, cancellationToken);
    }
}

