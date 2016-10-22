using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EAS.Financeiro.Models;
using EAS.Core;

namespace EAS.Financeiro.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<FoneContato> Telefones { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Estado> Estados { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            #region empresas

            builder.Entity<Empresa>().HasKey(t => t.Id);
            builder.Entity<Empresa>().Property(t => t.Nome).HasMaxLength(50).IsRequired();
            builder.Entity<Empresa>().Property(t => t.RazaoSocial).HasMaxLength(100).IsRequired();
            builder.Entity<Empresa>().Property(t => t.CNPJ).HasColumnType("char(14)");
            builder.Entity<Empresa>().Property(t => t.Ativa).IsRequired();
            builder.Entity<Empresa>().Property(t => t.DataCadastro).IsRequired();

            builder.Entity<Empresa>()
                .HasMany(t => t.Enderecos)
                .WithOne(t => t.Empresa)
                .HasForeignKey(t => t.EmpresaId);

            builder.Entity<Empresa>()
                .HasMany(t => t.Contatos)
                .WithOne(t => t.Empresa)
                .HasForeignKey(t => t.EmpresaId);

            builder.Entity<Empresa>()
                .HasOne(t => t.ApplicationUser)
                .WithMany(t => t.Empresas)
                .HasForeignKey(t => t.ApplicationUserId);

            #endregion

            #region contatos

            builder.Entity<Contato>().HasKey(t => t.Id);
            builder.Entity<Contato>().Property(t => t.Nome).HasMaxLength(50).IsRequired();
            builder.Entity<Contato>().Property(t => t.Email).HasMaxLength(60);
            builder.Entity<Contato>().Property(t => t.Tipo).HasMaxLength(30);

            builder.Entity<Contato>()
                .HasOne(t => t.Empresa)
                .WithMany(t => t.Contatos)
                .HasForeignKey(t => t.EmpresaId);

            #endregion

            #region telefones

            builder.Entity<FoneContato>().HasKey(t => t.Id);
            builder.Entity<FoneContato>().Property(t => t.DDI).HasColumnType("char(2)");
            builder.Entity<FoneContato>().Property(t => t.DDD).HasColumnType("char(2)");
            builder.Entity<FoneContato>().Property(t => t.Ramal).HasMaxLength(10);
            builder.Entity<FoneContato>().Property(t => t.Numero).HasColumnType("char(9)");
            builder.Entity<FoneContato>().Property(t => t.Operadora).HasMaxLength(30);
            builder.Entity<FoneContato>().Property(t => t.Tipo).HasMaxLength(30);
            builder.Entity<FoneContato>().Property(t => t.Observacao).HasMaxLength(150);

            builder.Entity<FoneContato>()
                .HasOne(t => t.Contato)
                .WithMany(t => t.Telefones)
                .HasForeignKey(t => t.ContatoId);

            #endregion

            #region endereços

            builder.Entity<Endereco>().HasKey(t => t.Id);
            builder.Entity<Endereco>().Property(t => t.Rua).HasMaxLength(150).IsRequired();
            builder.Entity<Endereco>().Property(t => t.Bairro).HasMaxLength(50);
            builder.Entity<Endereco>().Property(t => t.Cidade).HasMaxLength(50);
            builder.Entity<Endereco>().Property(t => t.CEP).HasColumnType("char(8)");
            builder.Entity<Endereco>().Property(t => t.Pais).HasMaxLength(50);
            builder.Entity<Endereco>().Property(t => t.Tipo).HasMaxLength(50);

            #endregion

            #region estados

            builder.Entity<Estado>().HasKey(t => t.Id);
            builder.Entity<Estado>().Property(t => t.Nome).HasMaxLength(50);
            builder.Entity<Estado>().Property(t => t.Sigla).HasColumnType("char(2)");
            builder.Entity<Estado>()
                .HasMany(t => t.Enderecos)
                .WithOne(t => t.Estado)
                .HasForeignKey(t => t.EstadoId);

            #endregion
        }
    }
}
