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
                new Rol("Despachante") { Id = 1 },
                new Rol("Cliente") { Id = 2 },
                new Rol("Asistente") { Id = 3 }
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
            );
        }
    }
}