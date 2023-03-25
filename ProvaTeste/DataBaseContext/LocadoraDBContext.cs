using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProvaTeste.Entities;

#nullable disable

namespace ProvaTeste.DataBaseContext
{
    public partial class LocadoraDBContext : DbContext
    {
        public LocadoraDBContext()
        {
        }

        public LocadoraDBContext(DbContextOptions<LocadoraDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Filmes> Filmes { get; set; }
        public virtual DbSet<Locacoes> Locacoes { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=FAT-NT-PCASSOLA\\SQLEXPRESS;Initial Catalog=LocadoraDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.Property(e => e.Endereco).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Sobrenome).IsUnicode(false);
            });

            modelBuilder.Entity<Filmes>(entity =>
            {
                entity.Property(e => e.Diretor).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Sinopsia).IsUnicode(false);
            });

            modelBuilder.Entity<Locacoes>(entity =>
            {
                entity.HasOne(d => d.FK_ClienteNavigation)
                    .WithMany(p => p.Locacoes)
                    .HasForeignKey(d => d.FK_Cliente)
                    .HasConstraintName("FK2");

                entity.HasOne(d => d.FK_FilmeNavigation)
                    .WithMany(p => p.Locacoes)
                    .HasForeignKey(d => d.FK_Filme)
                    .HasConstraintName("FK1");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.Property(e => e.Login).IsUnicode(false);

                entity.Property(e => e.Senha).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
