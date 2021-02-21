using System.Linq;
using DBCorp.CRM.Core.EntityFramework.EntityConfigurations.FunilAggregation;
using DBCorp.CRM.Core.EntityFramework.EntityConfigurations.NegocioAggregation;
using DBCorp.CRM.Domain.Models.FunilAggregation;
using DBCorp.CRM.Domain.Models.NegocioAggregation;
using DBCorp.Infrastructure.Domain.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DBCorp.CRM.Core
{
    public class CRMDbContext : DbContext
    {
        public CRMDbContext(DbContextOptions<CRMDbContext> options) : base(options) { }



        //public virtual DbSet<Usuario> Usuario { get; set; }

        public virtual DbSet<Funil> Funil { get; set; }
        public virtual DbSet<FunilEmpresa> FunilEmpresa { get; set; }
        public virtual DbSet<FunilEtapa> FunilEtapa { get; set; }
        public virtual DbSet<Negocio> Negocio { get; set; }
        //public virtual DbSet<NegocioAtividade> NegocioAtividade { get; set; }
        //public virtual DbSet<NegocioHistorico> NegocioHistorico { get; set; }
        //public virtual DbSet<NegocioObservacao> NegocioObservacao { get; set; }
        //public virtual DbSet<NegocioParticipante> NegocioParticipante { get; set; }
        //public virtual DbSet<NegocioSeguidor> NegocioSeguidor { get; set; }
        //public virtual DbSet<Participante> Participante { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // /*Desabilitamos o delete em cascata em relacionamentos  
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.ApplyConfiguration(new FunilEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FunilEmpresaEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FunilEtapaEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new NegocioEntityTypeConfiguration());







            modelBuilder.Entity<Usuario>().HasOne(x => x.Pessoa)
           .WithMany(ad => ad.Usuarios)
           .HasForeignKey(ad => ad.PessoaId);



            // modelBuilder.Entity<Usuario>().HasKey(x => x.PessoaId);



        }
    }

    public class DBcorpNGContextDesignFactory : IDesignTimeDbContextFactory<CRMDbContext>
    {
        public CRMDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CRMDbContext>()
                       //.UseSqlServer("Server = localhost\\SQLEXPRESS01; Database = DBCorpNG; Trusted_Connection = True;");
                        .UseSqlServer(@"Data Source=cloud.dbcorp.com.br\dbc2,1435;Initial Catalog=DBCorpNG;Persist Security Info=True;User ID=user_DBCorpNG;Password=SXU8x1j4L4GpIRad7A6WRNA76");
                     //  .UseSqlServer(@"Data Source=192.168.0.9\dbc2,1435;Initial Catalog=DBCorpNG;Persist Security Info=True;User ID=user_DBCorpNG;Password=SXU8x1j4L4GpIRad7A6WRNA76");
            return new CRMDbContext(optionsBuilder.Options);
        }
    }
}