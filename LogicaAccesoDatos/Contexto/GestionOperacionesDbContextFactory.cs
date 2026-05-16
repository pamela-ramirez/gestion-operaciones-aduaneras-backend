using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LogicaAccesoDatos.Contexto
{
    public class GestionOperacionesDbContextFactory : IDesignTimeDbContextFactory<GestionOperacionesDbContext>
    {
        public GestionOperacionesDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GestionOperacionesDbContext>();

            // Cadena de conexión con servidor SQL

            //Romina
            //optionsBuilder.UseSqlServer("Server=LAPTOP-7HNCQVS5\\SQLEXPRESS1;Database=GestionOperacionesAduaneras;Trusted_Connection=true;TrustServerCertificate=true;");

            //Pamela
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=GestionOperacionesAduaneras;Trusted_Connection=true;TrustServerCertificate=true;");
            return new GestionOperacionesDbContext(optionsBuilder.Options);
        }
    }
}
