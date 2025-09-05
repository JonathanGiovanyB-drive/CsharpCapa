

namespace Capacitacion.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangeAsync(CancellationToken cancellationToken);
    }
}
