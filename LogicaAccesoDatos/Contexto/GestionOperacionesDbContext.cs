using LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Contexto
{
    public class GestionOperacionesDbContext : DbContext
    {
        public GestionOperacionesDbContext(
            DbContextOptions<GestionOperacionesDbContext> options)
            : base(options)
        {
        }

        // Tablas de la base de datos
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Despachante> Despachantes { get; set; }
        public DbSet<Rol> Roles { get; set; }

        public DbSet<Rol> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la tabla Rol
            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("Roles");
                entity.HasKey(r => r.Id);

                entity.Property(r => r.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(r => r.NombreRol)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasIndex(r => r.NombreRol)
              .IsUnique();
            });


            // Configuración de herencia TPH (Table Per Hierarchy) con discriminador para manehar jerarquia
            modelBuilder.Entity<Usuario>()
                .HasDiscriminator<int>("Discriminator")
                .HasValue<Usuario>(0)
                .HasValue<Cliente>(1)
                .HasValue<Despachante>(2);

            // Configuración de la tabla Usuario
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuarios");
                entity.HasKey(u => u.Id);

                entity.Property(u => u.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(u => u.Apellido)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.OwnsOne(u => u.Email, email =>
                {
                    email.Property(e => e.Valor)
                        .HasColumnName("Email")
                        .IsRequired()
                        .HasMaxLength(150);
                });

                //entity.HasIndex("Email")
                //    .IsUnique();

                entity.OwnsOne(u => u.Password, password =>
                {
                    password.Property(p => p.Valor)
                        .HasColumnName("PasswordHash")
                        .IsRequired();
                });

                //entity.Property(u => u.Rol)
                //    .IsRequired();
                entity.HasOne(u => u.Rol)
                    .WithMany()
                    .HasForeignKey(u => u.RolId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de la tabla Cliente (hereda de Usuario)
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(c => c.Rut)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("Rut");

                entity.HasIndex("Rut")
                    .IsUnique();
            });

            // Configuración de la tabla Despachante (hereda de Usuario)
            modelBuilder.Entity<Despachante>(entity =>
            {
                entity.Property(d => d.Rut)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("Rut");

                entity.HasIndex("Rut")
                    .IsUnique();
            });
        }

    }
}
