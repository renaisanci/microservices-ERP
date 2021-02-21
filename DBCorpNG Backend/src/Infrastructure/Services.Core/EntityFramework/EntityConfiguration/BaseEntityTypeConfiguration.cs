using System;
using DBCorp.Infrastructure.Domain.Core.Model;
using DBCorp.Infrastructure.Services.Core.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBCorp.Infrastructure.Services.Core.EntityFramework.EntityConfiguration
{
	public abstract class BaseEntityTypeConfiguration<TEntity, TSchema> : IEntityTypeConfiguration<TEntity> where TEntity : BaseModel
																											where TSchema : BaseSchema
	{
		public abstract void ImplementConfigure(EntityTypeBuilder<TEntity> builder);

		public void Configure(EntityTypeBuilder<TEntity> builder)
		{
			builder.ToTable(typeof(TEntity).Name, Activator.CreateInstance<TSchema>().ToString());
			builder.HasKey(m => m.Id);
			builder.Property(m => m.Id).ValueGeneratedOnAdd();



            //  builder.Property(e => e.UsuarioCriacaoId).IsRequired();
            //  builder.Property(e => e.UsuarioAlteracaoId).IsRequired();

            builder.HasOne(d => d.UsuarioAlteracao)
            .WithMany()
            .HasForeignKey(d => d.UsuarioAlteracaoId)
            .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.UsuarioCriacao)
         .WithMany()
         .HasForeignKey(d => d.UsuarioCriacaoId)
         .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Property(e => e.DataHoraCriacao).IsRequired().HasDefaultValueSql("getdate()");
			builder.Property(e => e.DataHoraAlteracao).IsRequired(false);
			builder.Property(e => e.Ativo).HasDefaultValue(true).IsRequired();
			builder.Property(e => e.Excluido).HasDefaultValue(false).IsRequired();

			this.ImplementConfigure(builder);
		}
	}
}