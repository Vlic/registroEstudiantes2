using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace registroEstudiantes2.Models
{
    public partial class registroEstudiantesContext : DbContext
    {
        public registroEstudiantesContext()
        {
        }

        public registroEstudiantesContext(DbContextOptions<registroEstudiantesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Estudiantes> Estudiantes { get; set; }
        public virtual DbSet<Materias> Materias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-F3JOOQ3C\\SQLEXPRESS;Database=registroEstudiantes;User Id=sa;Password=sa");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Estudiantes>(entity =>
            {
                entity.HasKey(e => e.IdEstudiante)
                    .HasName("PK__estudian__EC5D9B1CA3241ED7");

                entity.ToTable("estudiantes");

                entity.Property(e => e.IdEstudiante).HasColumnName("id_Estudiante");

                entity.Property(e => e.Apellido)
                    .HasColumnName("apellido")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.IdMateria).HasColumnName("id_Materia");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.IdMateria)
                    .HasConstraintName("FK__estudiant__id_Ma__4BAC3F29");
            });

            modelBuilder.Entity<Materias>(entity =>
            {
                entity.HasKey(e => e.IdMateria)
                    .HasName("PK__materias__2CDC8FCD390C4DD9");

                entity.ToTable("materias");

                entity.Property(e => e.IdMateria).HasColumnName("id_Materia");

                entity.Property(e => e.Nivel).HasColumnName("nivel");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
