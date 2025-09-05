
namespace Capacitacion.Domain.Roles
{
    public interface IRolRepository
    {        
        Task<List<Rol>> GetAll();
        void Add(Rol rol);
    }
}
