using LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using LogicaNegocio.Entidades;
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
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuracion de herencia
            // Le indica a Entity Framework como manejar
            // las clases hijas de Usuario
            modelBuilder.Entity<Usuario>()
                .HasDiscriminator<int>("Rol")
                .HasValue<Usuario>(0)
                .HasValue<Despachante>((int)Rol.Despachante)
                .HasValue<Cliente>((int)Rol.Cliente);

            // Configuracion de la tabla Usuario
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuarios");
                entity.HasKey(u => u.Id);
                entity.Property(u => u.NombreCompleto)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(u => u.CorreoElectronico)
                    .IsRequired()
                    .HasMaxLength(150);
                entity.HasIndex(u => u.CorreoElectronico)
                    .IsUnique();
                entity.Property(u => u.ContrasenaHash)
                    .IsRequired();
                entity.Property(u => u.Rol)
                    .IsRequired();
            });

            // Configuracion de la tabla Cliente
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(c => c.RUT)
                    .IsRequired()
                    .HasMaxLength(20);
                entity.HasIndex(c => c.RUT)
                    .IsUnique(); // RN-04.1: RUT unico
                entity.Property(c => c.Telefono)
                    .IsRequired()
                    .HasMaxLength(20);
                entity.Property(c => c.Direccion)
                    .HasMaxLength(200);
            });

            // Datos iniciales: crear un despachante por defecto
            // La contrasena es: Admin1234
            modelBuilder.Entity<Despachante>().HasData(new Despachante
            {
                Id = 1,
                NombreCompleto = "Administrador",
                CorreoElectronico = "admin@aduanas.com",
                ContrasenaHash = BCrypt.Net.BCrypt.HashPassword("Admin1234"),
                Rol = Rol.Despachante,
                Activo = true,
                FechaCreacion = new DateTime(2026, 1, 1)
            });
        }*/

    }
}
