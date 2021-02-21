﻿// <auto-generated />
using System;
using DBCorp.Infraestrutura.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DBCorp.Infraestrutura.Core.Migrations
{
    [DbContext(typeof(InfraestruturaDbContext))]
    partial class InfraestruturaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DBCorp.ControleAcesso.Domain.Model.PessoaFisica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<string>("Cpf");

                    b.Property<DateTime?>("DataHoraAlteracao");

                    b.Property<DateTime>("DataHoraCriacao")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime?>("DataNascimento");

                    b.Property<bool>("Excluido")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("Nome");

                    b.Property<int>("PessoaId");

                    b.Property<string>("Rg");

                    b.Property<string>("Sobrenome");

                    b.Property<int?>("UsuarioAlteracaoId");

                    b.Property<int?>("UsuarioCriacaoId");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId")
                        .IsUnique();

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioCriacaoId");

                    b.ToTable("PessoaFisica","Infraestrutura");
                });

            modelBuilder.Entity("DBCorp.ControleAcesso.Domain.Model.PessoaJuridica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<string>("Cnpj");

                    b.Property<DateTime?>("DataHoraAlteracao");

                    b.Property<DateTime>("DataHoraCriacao")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime?>("DtFundacao");

                    b.Property<bool>("Excluido")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("InscEstadual");

                    b.Property<string>("NomeFantasia");

                    b.Property<int>("PessoaId");

                    b.Property<string>("RazaoSocial");

                    b.Property<int?>("UsuarioAlteracaoId");

                    b.Property<int?>("UsuarioCriacaoId");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId")
                        .IsUnique();

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioCriacaoId");

                    b.ToTable("PessoaJuridica","Infraestrutura");
                });

            modelBuilder.Entity("DBCorp.Infrastructure.Domain.Core.Model.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("DataHoraAlteracao");

                    b.Property<DateTime>("DataHoraCriacao")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<bool>("Excluido")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<int>("TipoPessoa");

                    b.Property<int?>("UsuarioAlteracaoId");

                    b.Property<int?>("UsuarioCriacaoId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioCriacaoId");

                    b.ToTable("Pessoa","Infraestrutura");
                });

            modelBuilder.Entity("DBCorp.Infrastructure.Domain.Core.Model.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo");

                    b.Property<DateTime?>("DataHoraAlteracao");

                    b.Property<DateTime>("DataHoraCriacao");

                    b.Property<bool>("Excluido");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<int>("PessoaId");

                    b.Property<string>("PrimeiroNome");

                    b.Property<int>("TipoUsuario");

                    b.Property<string>("Token");

                    b.Property<string>("UltimoNome");

                    b.Property<string>("Username");

                    b.Property<int?>("UsuarioAlteracaoId");

                    b.Property<int?>("UsuarioCriacaoId");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.HasIndex("UsuarioAlteracaoId")
                        .IsUnique()
                        .HasFilter("[UsuarioAlteracaoId] IS NOT NULL");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("DBCorp.ControleAcesso.Domain.Model.PessoaFisica", b =>
                {
                    b.HasOne("DBCorp.Infrastructure.Domain.Core.Model.Pessoa", "Pessoa")
                        .WithOne()
                        .HasForeignKey("DBCorp.ControleAcesso.Domain.Model.PessoaFisica", "PessoaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DBCorp.Infrastructure.Domain.Core.Model.Usuario", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId");

                    b.HasOne("DBCorp.Infrastructure.Domain.Core.Model.Usuario", "UsuarioCriacao")
                        .WithMany()
                        .HasForeignKey("UsuarioCriacaoId");
                });

            modelBuilder.Entity("DBCorp.ControleAcesso.Domain.Model.PessoaJuridica", b =>
                {
                    b.HasOne("DBCorp.Infrastructure.Domain.Core.Model.Pessoa", "Pessoa")
                        .WithOne()
                        .HasForeignKey("DBCorp.ControleAcesso.Domain.Model.PessoaJuridica", "PessoaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DBCorp.Infrastructure.Domain.Core.Model.Usuario", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId");

                    b.HasOne("DBCorp.Infrastructure.Domain.Core.Model.Usuario", "UsuarioCriacao")
                        .WithMany()
                        .HasForeignKey("UsuarioCriacaoId");
                });

            modelBuilder.Entity("DBCorp.Infrastructure.Domain.Core.Model.Pessoa", b =>
                {
                    b.HasOne("DBCorp.Infrastructure.Domain.Core.Model.Usuario", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId");

                    b.HasOne("DBCorp.Infrastructure.Domain.Core.Model.Usuario", "UsuarioCriacao")
                        .WithMany()
                        .HasForeignKey("UsuarioCriacaoId");
                });

            modelBuilder.Entity("DBCorp.Infrastructure.Domain.Core.Model.Usuario", b =>
                {
                    b.HasOne("DBCorp.Infrastructure.Domain.Core.Model.Pessoa", "Pessoa")
                        .WithMany("Usuarios")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DBCorp.Infrastructure.Domain.Core.Model.Usuario", "UsuarioAlteracao")
                        .WithOne("UsuarioCriacao")
                        .HasForeignKey("DBCorp.Infrastructure.Domain.Core.Model.Usuario", "UsuarioAlteracaoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
