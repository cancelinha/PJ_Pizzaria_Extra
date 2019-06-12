using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pizzarias.Extra.WebApi.Domains
{
    public partial class PizzariasContext : DbContext
    {
        public PizzariasContext()
        {
        }

        public PizzariasContext(DbContextOptions<PizzariasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoriaPreco> CategoriaPreco { get; set; }
        public virtual DbSet<Pizzaria> Pizzarias { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog = Senai_Pizzarias; user id = sa; pwd = 132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaPreco>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.ToTable("CATEGORIA_PRECO");

                entity.HasIndex(e => e.Categoria)
                    .HasName("UQ__CATEGORI__DC9274C7A68CA515")
                    .IsUnique();

                entity.HasIndex(e => e.Preco)
                    .HasName("UQ__CATEGORI__06A6C47B38878BA6")
                    .IsUnique();

                entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasColumnName("CATEGORIA")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Preco)
                    .IsRequired()
                    .HasColumnName("PRECO")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pizzaria>(entity =>
            {
                entity.HasKey(e => e.IdPizzaria);

                entity.ToTable("PIZZARIAS");

                entity.HasIndex(e => e.Endereco)
                    .HasName("UQ__PIZZARIA__AF82008D7827E138")
                    .IsUnique();

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__PIZZARIA__E2AB1FF42DD2BC7E")
                    .IsUnique();

                entity.HasIndex(e => e.TelefoneComercial)
                    .HasName("UQ__PIZZARIA__EADCFA2F2E17D7A5")
                    .IsUnique();

                entity.Property(e => e.IdPizzaria).HasColumnName("ID_PIZZARIA");

                entity.Property(e => e.CategoriaDoPreco).HasColumnName("CATEGORIA_DO_PRECO");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasColumnName("ENDERECO")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.OpcaoVegana)
                    .IsRequired()
                    .HasColumnName("OPCAO_VEGANA")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TelefoneComercial)
                    .IsRequired()
                    .HasColumnName("TELEFONE_COMERCIAL")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CategoriaDoPrecoNavigation)
                    .WithMany(p => p.Pizzarias)
                    .HasForeignKey(d => d.CategoriaDoPreco)
                    .HasConstraintName("FK__PIZZARIAS__CATEG__5812160E");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario);

                entity.ToTable("TIPO_USUARIO");

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__TIPO_USU__E2AB1FF41A024898")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario).HasColumnName("ID_TIPO_USUARIO");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("USUARIO");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__USUARIO__161CF724A1EBFF6C")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDeUsuario).HasColumnName("TIPO_DE_USUARIO");

                entity.HasOne(d => d.TipoDeUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.TipoDeUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIO__TIPO_DE__4D94879B");
            });
        }
    }
}
