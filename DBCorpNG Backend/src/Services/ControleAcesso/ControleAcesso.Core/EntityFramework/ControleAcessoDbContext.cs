using System.Linq;
using DBCorp.ControleAcesso.Core.EntityConfigurations;
using DBCorp.ControleAcesso.Domain.Model;
using DBCorp.Infrastructure.Domain.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DBCorp.ControleAcesso.Core
{
	public class ControleAcessoDbContext : DbContext
	{
		public ControleAcessoDbContext(DbContextOptions<ControleAcessoDbContext> options) : base(options) { }


        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        public virtual DbSet<Modulo> Modulo { get; set; }
		public virtual DbSet<Menu> Menu { get; set; }
		public virtual DbSet<MenuControle> MenuControle { get; set; }
 
		public virtual DbSet<Perfil> Perfil { get; set; }
		public virtual DbSet<PerfilUsuario> PerfilUsuario { get; set; }
		public virtual DbSet<PermisaoPerfil> PermisaoPerfil { get; set; }
 

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// /*Desabilitamos o delete em cascata em relacionamentos  
			foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
			{
				relationship.DeleteBehavior = DeleteBehavior.Restrict;
			}

			#region Menu
			modelBuilder.ApplyConfiguration(new MenuEntityTypeConfiguration());
			modelBuilder.ApplyConfiguration(new ModuloEntityTypeConfiguration());
			modelBuilder.ApplyConfiguration(new MenuControleEntityTypeConfiguration());

			#endregion

			#region Usuario
			modelBuilder.ApplyConfiguration(new PerfilEntityTypeConfiguration());
			modelBuilder.ApplyConfiguration(new PerfilUsuarioEntityTypeConfiguration());
			modelBuilder.ApplyConfiguration(new PermissaoPerfilEntityTypeConfiguration());
			modelBuilder.ApplyConfiguration(new UsuarioEntityTypeConfiguration());
			#endregion
		}
	}

	public class DBcorpNGContextDesignFactory : IDesignTimeDbContextFactory<ControleAcessoDbContext>
	{
		public ControleAcessoDbContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<ControleAcessoDbContext>()
				  //.UseSqlServer("Server = localhost\\SQLEXPRESS01; Database = DBCorpNG; Trusted_Connection = True;");
				  .UseSqlServer(@"Data Source=cloud.dbcorp.com.br\dbc2,1435;Initial Catalog=DBCorpNG;Persist Security Info=True;User ID=user_DBCorpNG;Password=SXU8x1j4L4GpIRad7A6WRNA76");
            // .UseSqlServer(@"Data Source=192.168.0.9\dbc2,1435;Initial Catalog=DBCorpNG;Persist Security Info=True;User ID=user_DBCorpNG;Password=SXU8x1j4L4GpIRad7A6WRNA76");


            return new ControleAcessoDbContext(optionsBuilder.Options);
		}
	}
}