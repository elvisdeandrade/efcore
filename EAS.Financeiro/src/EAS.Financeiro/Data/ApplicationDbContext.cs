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

            builder.Entity<Empresa>().HasKey(t => t.Id);
            builder.Entity<Empresa>().Property(t => t.Nome).HasMaxLength(50).IsRequired();
            builder.Entity<Empresa>().Property(t => t.RazaoSocial).HasMaxLength(100).IsRequired();
            builder.Entity<Empresa>().Property(t => t.CNPJ).HasMaxLength(14);
            builder.Entity<Empresa>().Property(t => t.Ativa).IsRequired();
            builder.Entity<Empresa>().Property(t => t.DataCadastro).IsRequired();

            builder.Entity<Contato>().HasKey(t => t.Id);
        }
    }
}
