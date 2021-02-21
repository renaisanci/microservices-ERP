using DBCorp.ControleAcesso.Domain.Model;
using DBCorp.Infrastructure.Services.Core.EntityFramework.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBCorp.ControleAcesso.Core.EntityConfigurations
{
	public class MenuEntityTypeConfiguration : BaseEntityTypeConfiguration<Menu, ControleAcessoSchema>
	{
		public override void ImplementConfigure(EntityTypeBuilder<Menu> builder)
		{
			builder.HasOne(d => d.Modulo)
					   .WithMany()
					   .HasForeignKey(d => d.ModuloId)
					   .OnDelete(DeleteBehavior.Restrict);

			builder.HasMany(m => m.MenuPai)
					   .WithOne(r => r.MenuFilho)
					   .HasForeignKey(r => r.MenuPaiId)
					   .OnDelete(DeleteBehavior.Restrict)
					   .IsRequired(false);

			builder.Property(e => e.ModuloId).IsRequired();
			builder.Property(e => e.DescMenu).HasColumnType("varchar(100)");
		}
	}
}
