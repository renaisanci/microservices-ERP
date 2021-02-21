using DBCorp.Infrastructure.Services.Core.EntityFramework.EntityConfiguration;
using DBCorp.Infrastructure.Domain.Core.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBCorp.ControleAcesso.Core.EntityConfigurations
{
	public class UsuarioEntityTypeConfiguration : BaseEntityTypeConfiguration<Usuario, ControleAcessoSchema>
	{
		public override void ImplementConfigure(EntityTypeBuilder<Usuario> usuarioBuilder)
		{
			usuarioBuilder.Property(u => u.PessoaId).IsRequired();
			usuarioBuilder.Property(u => u.PasswordHash).IsRequired();
			usuarioBuilder.Property(u => u.PasswordSalt).IsRequired();

            usuarioBuilder.HasOne(x => x.Pessoa)
            .WithMany(ad => ad.Usuarios)
            .HasForeignKey(ad => ad.PessoaId);
        }
	}
}