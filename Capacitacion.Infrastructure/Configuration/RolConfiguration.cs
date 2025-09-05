
using Capacitacion.Domain.Roles;
using Capacitacion.Domain.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Capacitacion.Infrastructure.Configuration
{
    internal sealed class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("roles");
            builder.HasKey(x => x.Id);
            builder.HasMany(r => r.Usuarios)
                .WithMany(u => u.Roles)
                .UsingEntity(j => j.ToTable("usuario_roles"));
        }
    }
}
