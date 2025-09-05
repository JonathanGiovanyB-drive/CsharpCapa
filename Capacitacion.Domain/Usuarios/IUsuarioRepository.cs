
namespace Capacitacion.Domain.Usuarios
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAll();
        Task<Usuario> GetByCode(string id);
        void Add(Usuario usuario);

    }
}
