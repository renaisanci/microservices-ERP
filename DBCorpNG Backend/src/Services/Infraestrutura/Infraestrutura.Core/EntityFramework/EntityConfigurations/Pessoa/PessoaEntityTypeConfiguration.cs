using DBCorp.ControleAcesso.Domain.Model;
using DBCorp.Infrastructure.Services.Core.EntityFramework.EntityConfiguration;
using DBCorp.Infrastructure.Domain.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBCorp.Infraestrutura.Core.EntityConfigurations
{
	public class PessoaEntityTypeConfiguration : BaseEntityTypeConfiguration<Pessoa, InfraestruturaSchema>
	{
		public override void ImplementConfigure(EntityTypeBuilder<Pessoa> pessoaBuilder)
		{
			pessoaBuilder.Property(p => p.TipoPessoa).IsRequired();

			pessoaBuilder.HasOne<PessoaJuridica>()
			.WithOne(ad => ad.Pessoa)
			.HasForeignKey<PessoaJuridica>(ad => ad.PessoaId);

			pessoaBuilder.HasOne<PessoaFisica>()
			.WithOne(ad => ad.Pessoa)
			.HasForeignKey<PessoaFisica>(ad => ad.PessoaId);


            pessoaBuilder.HasMany(m => m.Usuarios)
             .WithOne(r => r.Pessoa)
             .HasForeignKey(r => r.PessoaId)
             .OnDelete(DeleteBehavior.Restrict)
             .IsRequired();
        }
    }
}
