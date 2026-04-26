using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Contexto
{
    public class GestionOperacionesDbContextFactory : IDesignTimeDbContextFactory<GestionOperacionesDbContext>
    {
        public GestionOperacionesDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GestionOperacionesDbContext>();

            // Cadena de conexión con servidor SQL
            //optionsBuilder.UseSqlServer("Server=LAPTOP-7HNCQVS5\\SQLEXPRESS1;Database=GestionOperacionesAduaneras;Trusted_Connection=true;TrustServerCertificate=true;");
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=GestionOperacionesAduaneras;Trusted_Connection=true;TrustServerCertificate=true;"
            );
            return new GestionOperacionesDbContext(optionsBuilder.Options);
        }
    }
}