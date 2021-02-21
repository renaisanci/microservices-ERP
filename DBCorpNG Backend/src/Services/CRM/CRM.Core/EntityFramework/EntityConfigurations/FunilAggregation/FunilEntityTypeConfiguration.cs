using System;
using System.Collections.Generic;
using System.Text;
using DBCorp.ControleAcesso.Core;
using DBCorp.CRM.Domain.Models.FunilAggregation;
using DBCorp.Infrastructure.Services.Core.EntityFramework.EntityConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBCorp.CRM.Core.EntityFramework.EntityConfigurations.FunilAggregation
{
	public class FunilEntityTypeConfiguration : BaseEntityTypeConfiguration<Funil, CRMSchema>
	{
		public override void ImplementConfigure(EntityTypeBuilder<Funil> builder)
		{
			builder.Property(x => x.Titulo).IsRequired().HasMaxLength(50);
		}
	}
}
