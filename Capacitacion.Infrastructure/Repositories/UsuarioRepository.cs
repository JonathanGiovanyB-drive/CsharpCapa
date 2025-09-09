

using System.Data;
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
        Guid guiId = Guid.Parse(id);

        return await dbContext.Set<Usuario>().Where(x => x.Id == guiId).FirstOrDefaultAsync(cancellationToken);
    }
}

