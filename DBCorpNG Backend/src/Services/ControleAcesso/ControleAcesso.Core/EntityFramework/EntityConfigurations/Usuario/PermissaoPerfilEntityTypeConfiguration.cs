using DBCorp.ControleAcesso.Domain.Model;
using DBCorp.Infrastructure.Services.Core.EntityFramework.EntityConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBCorp.ControleAcesso.Core.EntityConfigurations
{
	public class PermissaoPerfilEntityTypeConfiguration : BaseEntityTypeConfiguration<PermisaoPerfil, ControleAcessoSchema>
	{
		public override void ImplementConfigure(EntityTypeBuilder<PermisaoPerfil> builder)
		{
			builder.Property(ur => ur.PerfilId).IsRequired();
			builder.Property(ur => ur.MenuControleId).IsRequired();
		}
	}
}