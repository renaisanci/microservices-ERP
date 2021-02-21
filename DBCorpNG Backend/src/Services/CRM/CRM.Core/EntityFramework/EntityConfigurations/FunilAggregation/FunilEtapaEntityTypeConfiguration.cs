using System;
using System.Collections.Generic;
using System.Text;
using DBCorp.ControleAcesso.Core;
using DBCorp.CRM.Domain.Models.FunilAggregation;
using DBCorp.Infrastructure.Services.Core.EntityFramework.EntityConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBCorp.CRM.Core.EntityFramework.EntityConfigurations.FunilAggregation
{
	public class FunilEtapaEntityTypeConfiguration : BaseEntityTypeConfiguration<FunilEtapa, CRMSchema>
	{
		public override void ImplementConfigure(EntityTypeBuilder<FunilEtapa> builder)
		{
			builder.HasOne(x => x.Funil).WithMany(x => x.Etapas).HasForeignKey(x => x.FunilId);
			builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
		}
	}
}
