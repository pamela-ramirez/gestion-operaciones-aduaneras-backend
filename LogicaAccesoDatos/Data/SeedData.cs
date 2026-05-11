using LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace LogicaAccesoDatos.Data
{
    public static class SeedData
    {
        public static void ConfigureSeedData(this ModelBuilder modelBuilder)
        {

            // ============================================================================
            // SEED DATA - ROLES
            // ============================================================================
            modelBuilder.Entity<Rol>().HasData(
                new Rol("Admin") { Id = 1 },
                new Rol("Despachante") { Id = 2 },
                new Rol("Cliente") { Id = 3 }
            );

            // ============================================================================
            // SEED DATA - TIPOS DE OPERACIÓN
            // ============================================================================
            modelBuilder.Entity<TipoOperacion>().HasData(
                new TipoOperacion("Importación") { Id = 1 },
                new TipoOperacion("Exportación") { Id = 2 }
            );

            // ============================================================================
            // SEED DATA - TIPOS DE CONOCIMIENTO
            // ============================================================================
            modelBuilder.Entity<TipoConocimiento>().HasData(
                new TipoConocimiento("Conocimiento de Embarque Marítimo") { Id = 1 },
                new TipoConocimiento("Guía Aérea") { Id = 2 },
                new TipoConocimiento("Carta de Porte Terrestre") { Id = 3 },
                new TipoConocimiento("Declaración de Tránsito") { Id = 4 }
                //Tipos de conocimiento (marítimo, terrestre, aéreo)
            );

            // ============================================================================
            // SEED DATA - TIPOS DE COMUNICACIÓN
            // ============================================================================
            /*modelBuilder.Entity<TipoComunicacion>().HasData(
                new TipoComunicacion("Cotización") { Id = 1 },
                new TipoComunicacion("Liquidación") { Id = 2 },
                new TipoComunicacion("Documentación y Facturación") { Id = 3 }

            );*/

            // ============================================================================
            // SEED DATA - DESPACHANTES
            // ============================================================================
            modelBuilder.Entity<Despachante>().HasData(
                new
                {
                    Id = 10,
                    Nombre = "Carlos",
                    Apellido = "Fernández",
                    RolId = 2,
                    Codigo = "DESP-001",
                    FechaCreacion = new DateTime(2025, 1, 10),
                    PrimerLogin = false,
                    Estado = EstadoUsuario.Activo
                },
                new
                {
                    Id = 11,
                    Nombre = "Valeria",
                    Apellido = "Ríos",
                    RolId = 2,
                    Codigo = "DESP-002",
                    FechaCreacion = new DateTime(2025, 3, 5),
                    PrimerLogin = false,
                    Estado = EstadoUsuario.Activo
                }
            );

            // ✅ Email y Password de Despachante → FK = "UsuarioId"
            //    (porque OwnsOne está configurado en Usuario base)
            modelBuilder.Entity<Despachante>().OwnsOne(d => d.Email).HasData(
                new { UsuarioId = 10, Valor = "carlos.fernandez@despacho.com.uy" },
                new { UsuarioId = 11, Valor = "valeria.rios@despacho.com.uy" }
            );
            modelBuilder.Entity<Despachante>().OwnsOne(d => d.Password).HasData(
                new { UsuarioId = 10, Valor = "Despacho100!" },
                new { UsuarioId = 11, Valor = "Despacho100!" }
            );

            // ============================================================================
            // SEED DATA - CLIENTES
            // ============================================================================
            modelBuilder.Entity<Cliente>().HasData(
                new
                {
                    Id = 20,
                    Nombre = "Martina",
                    Apellido = "González",
                    RolId = 3,
                    RazonSocial = "González Import S.R.L.",
                    Telefono = "099123456",
                    Direccion = (string?)"Av. 18 de Julio 1234, Montevideo",
                    FechaCreacion = new DateTime(2025, 2, 1),
                    PrimerLogin = false,
                    Estado = EstadoUsuario.Activo
                },
                new
                {
                    Id = 21,
                    Nombre = "Roberto",
                    Apellido = "Álvarez",
                    RolId = 3,
                    RazonSocial = "Álvarez Exportaciones S.A.",
                    Telefono = "098765432",
                    Direccion = (string?)"Rambla República Argentina 2040, Montevideo",
                    FechaCreacion = new DateTime(2025, 2, 15),
                    PrimerLogin = false,
                    Estado = EstadoUsuario.Activo
                },
                new
                {
                    Id = 22,
                    Nombre = "Laura",
                    Apellido = "Méndez",
                    RolId = 3,
                    RazonSocial = "Méndez & Asociados Ltda.",
                    Telefono = "091234567",
                    Direccion = (string?)"Bulevar Artigas 1500, Montevideo",
                    FechaCreacion = new DateTime(2025, 3, 20),
                    PrimerLogin = false,
                    Estado = EstadoUsuario.Activo
                }
            );

            // ✅ Email y Password de Cliente → FK = "UsuarioId"
            //    (misma configuración que Despachante, hereda de Usuario)
            modelBuilder.Entity<Cliente>().OwnsOne(c => c.Email).HasData(
                new { UsuarioId = 20, Valor = "martina.gonzalez@gonzalezimport.com.uy" },
                new { UsuarioId = 21, Valor = "roberto.alvarez@alvarezexport.com.uy" },
                new { UsuarioId = 22, Valor = "laura.mendez@mendezasociados.com.uy" }
            );
            modelBuilder.Entity<Cliente>().OwnsOne(c => c.Password).HasData(
                new { UsuarioId = 20, Valor = "Cliente100!" },
                new { UsuarioId = 21, Valor = "Cliente100!" },
                new { UsuarioId = 22, Valor = "Cliente100!" }
            );

            // ✅ Rut de Cliente → FK = "ClienteId"
            //    (configurado directamente en Cliente, no en Usuario base)
            modelBuilder.Entity<Cliente>().OwnsOne(c => c.Rut).HasData(
                new { ClienteId = 20, Valor = "21.234.567-8" },
                new { ClienteId = 21, Valor = "21.987.654-3" },
                new { ClienteId = 22, Valor = "21.456.789-0" }
            );
        }
    }
}