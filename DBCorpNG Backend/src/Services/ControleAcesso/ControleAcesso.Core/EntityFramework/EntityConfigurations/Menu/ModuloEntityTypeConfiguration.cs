using DBCorp.ControleAcesso.Domain.Model;
using DBCorp.Infrastructure.Services.Core.EntityFramework.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBCorp.ControleAcesso.Core.EntityConfigurations
{
	public class ModuloEntityTypeConfiguration : BaseEntityTypeConfiguration<Modulo, ControleAcessoSchema>
    {
        public override void ImplementConfigure(EntityTypeBuilder<Modulo> moduloBuilder)
        { 
            moduloBuilder.HasMany(m => m.Menus)
						 .WithOne(r => r.Modulo)
						 .HasForeignKey(r => r.ModuloId)
						 .OnDelete(DeleteBehavior.Restrict)
						 .IsRequired();
        }
    }
}
