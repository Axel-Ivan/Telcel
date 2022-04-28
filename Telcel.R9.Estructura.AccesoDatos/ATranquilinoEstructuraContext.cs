using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Telcel.R9.Estructura.AccesoDatos
{
    public partial class ATranquilinoEstructuraContext : DbContext
    {
        public ATranquilinoEstructuraContext()
        {
        }

        public ATranquilinoEstructuraContext(DbContextOptions<ATranquilinoEstructuraContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Departamento> Departamentos { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Puesto> Puestos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-2PSCNMSB; Database= ATranquilinoEstructura; Trusted_Connection=True; User ID=sa; Password=pass@word1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento)
                    .HasName("PK__Departam__787A433DEFDC4B12");

                entity.ToTable("Departamento");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PK__Empleado__CE6D8B9E67F0FB47");

                entity.ToTable("Empleado");

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdDepartamento)
                    .HasConstraintName("FK__Empleado__IdDepa__15502E78");

                entity.HasOne(d => d.IdPuestoNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdPuesto)
                    .HasConstraintName("FK__Empleado__IdPues__145C0A3F");
            });

            modelBuilder.Entity<Puesto>(entity =>
            {
                entity.HasKey(e => e.IdPuesto)
                    .HasName("PK__Puesto__ADAC6B9C09D529D2");

                entity.ToTable("Puesto");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
