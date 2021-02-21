using DBCorp.ControleAcesso.Core;
using DBCorp.CRM.Domain.Models.NegocioAggregation;
using DBCorp.Infrastructure.Services.Core.EntityFramework.EntityConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBCorp.CRM.Core.EntityFramework.EntityConfigurations.NegocioAggregation
{
   public class NegocioEntityTypeConfiguration : BaseEntityTypeConfiguration<Negocio, CRMSchema>
    {


        public override void ImplementConfigure(EntityTypeBuilder<Negocio> builder)
        {

            builder.Property(n => n.FunilEtapaId).IsRequired();

            builder.HasOne(x => x.FunilEtapa).WithMany(x => x.Negocios).HasForeignKey(x => x.FunilEtapaId);


        }


    }
}
