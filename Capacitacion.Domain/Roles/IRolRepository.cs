
namespace Capacitacion.Domain.Roles
{
    public interface IRolRepository
    {
        Task<List<Rol>> GetAll(CancellationToken cancellationToken);
        void Add(Rol rol);
        Task<Rol?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
