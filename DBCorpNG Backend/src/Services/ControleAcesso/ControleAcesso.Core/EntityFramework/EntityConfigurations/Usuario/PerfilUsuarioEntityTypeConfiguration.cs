using DBCorp.ControleAcesso.Domain.Model;
using DBCorp.Infrastructure.Services.Core.EntityFramework.EntityConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBCorp.ControleAcesso.Core.EntityConfigurations
{
	public class PerfilUsuarioEntityTypeConfiguration : BaseEntityTypeConfiguration<PerfilUsuario, ControleAcessoSchema>
	{
		public override void ImplementConfigure(EntityTypeBuilder<PerfilUsuario> perfilUsuarioBuilder)
		{
			perfilUsuarioBuilder.Property(ur => ur.UsuarioId).IsRequired();
			perfilUsuarioBuilder.Property(ur => ur.PerfilId).IsRequired();
		}
	}
}

