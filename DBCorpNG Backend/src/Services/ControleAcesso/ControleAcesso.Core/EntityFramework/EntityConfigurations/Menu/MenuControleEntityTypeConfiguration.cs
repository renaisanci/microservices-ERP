using DBCorp.ControleAcesso.Domain.Model;
using DBCorp.Infrastructure.Services.Core.EntityFramework.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBCorp.ControleAcesso.Core.EntityConfigurations
{
	public class MenuControleEntityTypeConfiguration : BaseEntityTypeConfiguration<MenuControle, ControleAcessoSchema>
	{
		public override void ImplementConfigure(EntityTypeBuilder<MenuControle> builder)
		{
	 


            
            builder.Property(e => e.MenuId).IsRequired();

            builder.Property(e => e.ElementName).IsRequired();
		}
	}
}
