using System.Linq;
using DBCorp.ControleAcesso.Domain.Model;
using DBCorp.Infraestrutura.Core.EntityConfigurations;
using DBCorp.Infrastructure.Domain.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DBCorp.Infraestrutura.Core
{
	public class InfraestruturaDbContext : DbContext
	{
		public InfraestruturaDbContext(DbContextOptions<InfraestruturaDbContext> options) : base(options) { }
		
		public virtual DbSet<Pessoa> Pessoa { get; set; }
		public virtual DbSet<PessoaFisica> PessoaFisica { get; set; }
		public virtual DbSet<PessoaJuridica> PessoaJuridica { get; set; }
		public virtual DbSet<Usuario> Usuario { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// /*Desabilitamos o delete em cascata em relacionamentos  
			foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
			{
				relationship.DeleteBehavior = DeleteBehavior.Restrict;
			}

			#region Pessoa
			modelBuilder.ApplyConfiguration(new PessoaEntityTypeConfiguration());
			modelBuilder.ApplyConfiguration(new PessoaFisicaEntityTypeConfiguration());
			modelBuilder.ApplyConfiguration(new PessoaJuridicaEntityTypeConfiguration());
			#endregion
		}
	}

	public class DBcorpNGContextDesignFactory : IDesignTimeDbContextFactory<InfraestruturaDbContext>
	{
		public InfraestruturaDbContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<InfraestruturaDbContext>()
                  //.UseSqlServer("Server = localhost\\SQLEXPRESS01; Database = DBCorpNG; Trusted_Connection = True;");
                 .UseSqlServer(@"Data Source=cloud.dbcorp.com.br\dbc2,1435;Initial Catalog=DBCorpNG;Persist Security Info=True;User ID=user_DBCorpNG;Password=SXU8x1j4L4GpIRad7A6WRNA76");

                 // .UseSqlServer(@"Data Source=192.168.0.9\dbc2,1435;Initial Catalog=DBCorpNG;Persist Security Info=True;User ID=user_DBCorpNG;Password=SXU8x1j4L4GpIRad7A6WRNA76");
            return new InfraestruturaDbContext(optionsBuilder.Options);
		}
	}
}