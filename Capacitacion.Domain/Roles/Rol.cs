
using Capacitacion.Domain.Abstractions;
using Capacitacion.Domain.Roles.Events;
using Capacitacion.Domain.Usuarios;

namespace Capacitacion.Domain.Roles
{
    public sealed class Rol : Entity
    {
        public string Name { get; set; }
        public int Nivel { get; set; }
        public Guid UsuarioId { get; set; }
        public ICollection<Usuario> Usuarios {  get; set; }
        private Rol() { }
        private Rol(Guid id, string name,int nivel) : base(id)
        {
            Name = name;
            Nivel = nivel;
            Usuarios = new HashSet<Usuario>();
        }
    public static Rol Create(string name, int nivel)
        {
            var rol = new Rol(Guid.NewGuid(), name, nivel);
            var rolDomainEvent = new RolCreateDomainEvent(rol.Id);
            rol.RiseDomainEvent(rolDomainEvent);
            return rol;
        }
    }
}
