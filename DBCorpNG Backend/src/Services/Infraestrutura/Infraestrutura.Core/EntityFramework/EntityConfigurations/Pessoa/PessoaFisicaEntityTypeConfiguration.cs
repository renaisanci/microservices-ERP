using DBCorp.ControleAcesso.Domain.Model;
using DBCorp.Infrastructure.Services.Core.EntityFramework.EntityConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBCorp.Infraestrutura.Core.EntityConfigurations
{
	public class PessoaFisicaEntityTypeConfiguration : BaseEntityTypeConfiguration<PessoaFisica, InfraestruturaSchema>
	{
		public override void ImplementConfigure(EntityTypeBuilder<PessoaFisica> builder)
		{
			builder.Property(e => e.PessoaId).IsRequired();
		}
	}
}
