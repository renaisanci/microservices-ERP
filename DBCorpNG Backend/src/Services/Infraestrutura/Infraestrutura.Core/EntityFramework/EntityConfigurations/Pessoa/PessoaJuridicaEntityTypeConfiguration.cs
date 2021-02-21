using DBCorp.ControleAcesso.Domain.Model;
using DBCorp.Infrastructure.Services.Core.EntityFramework.EntityConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBCorp.Infraestrutura.Core.EntityConfigurations
{
	public class PessoaJuridicaEntityTypeConfiguration : BaseEntityTypeConfiguration<PessoaJuridica, InfraestruturaSchema>
    {
        public override void ImplementConfigure(EntityTypeBuilder<PessoaJuridica> pessoaJuridicaBuilder)
        {
            pessoaJuridicaBuilder.Property(e => e.PessoaId).IsRequired();
        }
    }
}
