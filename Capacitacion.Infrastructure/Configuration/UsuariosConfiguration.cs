
using Capacitacion.Domain.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Capacitacion.Infrastructure.Configuration
{
    internal sealed class UsuariosConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuarios");
            builder.HasKey(x => x.Id);
            builder.HasMany(u => u.Roles)
                   .WithMany(r => r.Usuarios)
                   .UsingEntity(j => j.ToTable("usuario_roles"));
        }
    }
}
