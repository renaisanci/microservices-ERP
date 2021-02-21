using System;
using System.Collections.Generic;
using System.Text;
using DBCorp.ControleAcesso.Core;
using DBCorp.CRM.Domain.Models.FunilAggregation;
using DBCorp.Infrastructure.Services.Core.EntityFramework.EntityConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBCorp.CRM.Core.EntityFramework.EntityConfigurations.FunilAggregation
{
	public class FunilEmpresaEntityTypeConfiguration : BaseEntityTypeConfiguration<FunilEmpresa, CRMSchema>
	{
		public override void ImplementConfigure(EntityTypeBuilder<FunilEmpresa> builder)
		{
			builder.HasOne(x => x.Funil).WithMany(x => x.Empresas).HasForeignKey(x => x.FunilId);
			builder.HasOne(x => x.Empresa).WithMany().HasForeignKey(x => x.EmpresaId);
		}
	}
}
