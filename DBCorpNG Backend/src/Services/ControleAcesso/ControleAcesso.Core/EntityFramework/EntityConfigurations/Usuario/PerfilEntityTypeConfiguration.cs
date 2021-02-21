using DBCorp.ControleAcesso.Domain.Model;
using DBCorp.Infrastructure.Services.Core.EntityFramework.EntityConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBCorp.ControleAcesso.Core.EntityConfigurations
{
	public class PerfilEntityTypeConfiguration : BaseEntityTypeConfiguration<Perfil, ControleAcessoSchema>
	{
		public override void ImplementConfigure(EntityTypeBuilder<Perfil> perfilBuilder)
		{
			perfilBuilder.Property(p => p.DescPerfil).IsRequired().HasMaxLength(50);
		}
	}
}
