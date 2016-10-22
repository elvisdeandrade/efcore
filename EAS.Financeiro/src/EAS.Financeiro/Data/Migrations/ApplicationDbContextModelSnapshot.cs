using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EAS.Financeiro.Data;

namespace EAS.Financeiro.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EAS.Core.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("EAS.Core.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 60);

                    b.Property<int>("EmpresaId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Tipo")
                        .HasAnnotation("MaxLength", 30);

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("EAS.Core.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<bool>("Ativa");

                    b.Property<string>("CNPJ")
                        .HasColumnType("char(14)");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("EAS.Core.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("CEP")
                        .HasColumnType("char(8)");

                    b.Property<string>("Cidade")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<int>("EmpresaId");

                    b.Property<int>("EstadoId");

                    b.Property<string>("Observacao");

                    b.Property<string>("Pais")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 150);

                    b.Property<string>("Tipo")
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("EstadoId");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("EAS.Core.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Sigla")
                        .HasColumnType("char(2)");

                    b.HasKey("Id");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("EAS.Core.FoneContato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ContatoId");

                    b.Property<string>("DDD")
                        .HasColumnType("char(2)");

                    b.Property<string>("DDI")
                        .HasColumnType("char(2)");

                    b.Property<string>("Numero")
                        .HasColumnType("char(9)");

                    b.Property<string>("Observacao")
                        .HasAnnotation("MaxLength", 150);

                    b.Property<string>("Operadora")
                        .HasAnnotation("MaxLength", 30);

                    b.Property<string>("Ramal")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("Tipo")
                        .HasAnnotation("MaxLength", 30);

                    b.HasKey("Id");

                    b.HasIndex("ContatoId");

                    b.ToTable("Telefones");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("EAS.Core.Contato", b =>
                {
                    b.HasOne("EAS.Core.Empresa", "Empresa")
                        .WithMany("Contatos")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EAS.Core.Empresa", b =>
                {
                    b.HasOne("EAS.Core.ApplicationUser", "ApplicationUser")
                        .WithMany("Empresas")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("EAS.Core.Endereco", b =>
                {
                    b.HasOne("EAS.Core.Empresa", "Empresa")
                        .WithMany("Enderecos")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EAS.Core.Estado", "Estado")
                        .WithMany("Enderecos")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EAS.Core.FoneContato", b =>
                {
                    b.HasOne("EAS.Core.Contato", "Contato")
                        .WithMany("Telefones")
                        .HasForeignKey("ContatoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EAS.Core.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EAS.Core.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EAS.Core.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
