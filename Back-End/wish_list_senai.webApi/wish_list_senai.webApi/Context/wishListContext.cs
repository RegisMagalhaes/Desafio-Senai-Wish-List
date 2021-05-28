using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using wish_list_senai.webApi.Domains;

#nullable disable

namespace wish_list_senai.webApi.Context
{
    public partial class wishListContext : DbContext
    {
        public wishListContext()
        {
        }

        public wishListContext(DbContextOptions<wishListContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Desejo> Desejos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-5IAR0TCC; Database=wish_list_senai; user Id=sa; pwd=senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Desejo>(entity =>
            {
                entity.HasKey(e => e.IdDesejo)
                    .HasName("PK__desejos__5DB1341F4EBD997C");

                entity.ToTable("desejos");

                entity.HasIndex(e => e.Descricao, "UQ__desejos__91D38C28EC56F09F")
                    .IsUnique();

                entity.Property(e => e.IdDesejo).HasColumnName("idDesejo");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Desejos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__desejos__idUsuar__286302EC");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuarios__645723A6D3CA3850");

                entity.ToTable("usuarios");

                entity.HasIndex(e => e.Email, "UQ__usuarios__AB6E6164A551AD22")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("senha");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
