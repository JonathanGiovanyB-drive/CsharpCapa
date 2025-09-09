
namespace Capacitacion.Domain.Usuarios
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetByCode(string id, CancellationToken cancellationToken);
        Task<List<Usuario>> GetAll(CancellationToken cancellationToken);
        void Add(Usuario usuario);
        Task<Usuario?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    }
}
