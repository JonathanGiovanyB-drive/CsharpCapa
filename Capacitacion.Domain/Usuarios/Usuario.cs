
using Capacitacion.Domain.Abstractions;
using Capacitacion.Domain.Roles;
using Capacitacion.Domain.Usuarios.Events;

namespace Capacitacion.Domain.Usuarios
{
    public class Usuario : Entity
    {
        public string? Name { get; private set; }
        public string? Email { get; private set; }
        public string? Password { get; private set; }
        public ICollection<Rol> Roles { get; private set; }

        private Usuario(){}
        private Usuario(Guid id, string name, string email, string password) : base(id) 
        {
            Name = name;
            Email = email;
            Password = password;
            Roles = new HashSet<Rol>();
        }
        public static Usuario Create(string name,string email,string password)
        {
            var usuario = new Usuario(Guid.NewGuid(),name,email,password);
            var usuarioDomainEvent = new UsuarioCreateDomainEvent(usuario.Id);
            usuario.RiseDomainEvent(usuarioDomainEvent);
            return usuario;
        }
    }
}
