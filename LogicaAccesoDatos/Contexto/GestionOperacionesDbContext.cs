using LogicaAccesoDatos.Data;
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
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Despachante> Despachantes { get; set; }
        public DbSet<TipoOperacion> TiposOperacion { get; set; }
        public DbSet<TipoConocimiento> TiposConocimiento { get; set; }
        public DbSet<Operacion> Operaciones { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Liquidacion> Liquidaciones { get; set; }
        public DbSet<DetalleLiquidacion> DetallesLiquidacion { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<ValidacionPago> ValidacionesPago { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Asunto> Asuntos { get; set; }
        public DbSet<TipoComunicacion> TiposComunicacion { get; set; }
        public DbSet<Comunicacion> Comunicaciones { get; set; }


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
                    .HasMaxLength(100)
                    .HasColumnName("NombreRol");

                entity.HasIndex(r => r.NombreRol)
              .IsUnique()
              .HasDatabaseName("IX_Roles_NombreRol_Unique");
            });


            // Configuración de herencia TPH (Table Per Hierarchy) con discriminador para manejar jerarquia
            modelBuilder.Entity<Usuario>()
                .HasDiscriminator<int>("Discriminator")
                .HasValue<Usuario>(0)
                .HasValue<Cliente>(1)
                .HasValue<Despachante>(2);
            //TODO - Agregar clase admin (nuevo rol)

            // Configuración de la tabla Usuario
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuarios");
                entity.HasKey(u => u.Id);

                entity.Property(u => u.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(u => u.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Nombre");

                entity.Property(u => u.Apellido)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Apellido");

                // Configuración del value object email
                entity.OwnsOne(u => u.Email, email =>
                {
                    email.Property(e => e.Valor)
                        .HasColumnName("Email")
                        .IsRequired()
                        .HasMaxLength(150);
                });

                
                //
                entity.OwnsOne(u => u.Email)
                    .HasIndex(e => e.Valor)
                    .IsUnique()
                    .HasDatabaseName("IX_Usuarios_Email_Unique");
                //

                // Configuración del value object password
                entity.OwnsOne(u => u.Password, password =>
                {
                    password.Property(p => p.Valor)
                        .HasColumnName("PasswordHash")
                        .IsRequired();
                });
                
                entity.HasOne(u => u.Rol)
                    .WithMany()
                    .HasForeignKey(u => u.RolId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de la tabla Cliente
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(c => c.Rut)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("RUT");

                entity.HasIndex(c => c.Rut)
                    .IsUnique()
                    .HasDatabaseName("IX_Clientes_RUT_Unique");

                entity.Property(c => c.Telefono)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("Telefono");

                entity.Property(c => c.Direccion)
                    .HasMaxLength(300)
                    .HasColumnName("Direccion");
            });

            // Configuración de la tabla Despachante
            modelBuilder.Entity<Despachante>(entity =>
            {
                entity.Property(d => d.Rut)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("RUT");

                entity.HasIndex(d => d.Rut)
                    .IsUnique()
                    .HasDatabaseName("IX_Despachantes_RUT_Unique");
            });

            // Configuración de la tabla tipo operación
            modelBuilder.Entity<TipoOperacion>(entity =>
            {
                entity.ToTable("TiposOperacion");
                entity.HasKey(t => t.Id);

                entity.Property(t => t.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(t => t.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("Descripcion");

                entity.HasIndex(t => t.Descripcion)
                    .IsUnique()
                    .HasDatabaseName("IX_TiposOperacion_Descripcion_Unique");
            });

            // Configuracio de la tabla tipo conocimiento
            modelBuilder.Entity<TipoConocimiento>(entity =>
            {
                entity.ToTable("TiposConocimiento");
                entity.HasKey(t => t.Id);

                entity.Property(t => t.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(t => t.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("Descripcion");

                entity.HasIndex(t => t.Descripcion)
                    .IsUnique()
                    .HasDatabaseName("IX_TiposConocimiento_Descripcion_Unique");
            });

            // Configuración de la tabla Operación
            modelBuilder.Entity<Operacion>(entity =>
            {
                entity.ToTable("Operaciones");
                entity.HasKey(o => o.Id);

                entity.Property(o => o.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(o => o.NroCarpeta)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("NroCarpeta");

                entity.Property(o => o.FechaRegistro)
                    .IsRequired()
                    .HasColumnName("FechaRegistro")
                    .HasDefaultValue(DateTime.Now);

                entity.Property(o => o.Estado)
                    .IsRequired()
                    .HasColumnName("Estado");

                entity.Property(o => o.NroDua)
                    .HasColumnName("NroDua");

                entity.Property(o => o.NroConocimiento)
                    .HasColumnName("NroConocimiento");

                // Relación con TipoOperacion
                entity.HasOne(o => o.TipoOperacion)
                    .WithMany()
                    .HasForeignKey(o => o.TipoOperacionId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                // Relación con Cliente
                entity.HasOne(o => o.Cliente)
                    .WithMany()
                    .HasForeignKey(o => o.ClienteId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                // Relación con TipoConocimiento
                entity.HasOne(o => o.TipoConocimiento)
                    .WithMany()
                    .HasForeignKey(o => o.TipoConocimientoId)
                    .OnDelete(DeleteBehavior.SetNull);

                // Relaciones de colecciones
                entity.HasMany(o => o.Liquidaciones)
                    .WithOne(l => l.Operacion)
                    .HasForeignKey(l => l.OperacionId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(o => o.Documentos)
                    .WithOne(d => d.Operacion)
                    .HasForeignKey(d => d.OperacionId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(o => o.Comunicaciones)
                    .WithOne(c => c.Operacion)
                    .HasForeignKey(c => c.OperacionId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasIndex(o => o.NroCarpeta)
                    .IsUnique()
                    .HasDatabaseName("IX_Operaciones_NroCarpeta_Unique");
            });

            // Configuración de la tabla documento
            modelBuilder.Entity<Documento>(entity =>
            {
                entity.ToTable("Documentos");
                entity.HasKey(d => d.Id);

                entity.Property(d => d.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(d => d.Nombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("Nombre");

                entity.Property(d => d.RutaArchivo)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("RutaArchivo");

                entity.Property(d => d.Formato)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("Formato");

                entity.Property(d => d.FechaCarga)
                    .IsRequired()
                    .HasColumnName("FechaCarga")
                    .HasDefaultValue(DateTime.Now);

                entity.HasOne(d => d.Operacion)
                    .WithMany(o => o.Documentos)
                    .HasForeignKey(d => d.OperacionId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuración de la tabla liquidación
            modelBuilder.Entity<Liquidacion>(entity =>
            {
                entity.ToTable("Liquidaciones");
                entity.HasKey(l => l.Id);

                entity.Property(l => l.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(l => l.FechaEnvio)
                    .IsRequired()
                    .HasColumnName("FechaEnvio");

                entity.Property(l => l.FechaVenc)
                    .IsRequired()
                    .HasColumnName("FechaVenc");

                entity.Property(l => l.MontoTotal)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)")
                    .HasColumnName("MontoTotal");

                entity.Property(l => l.SaldoPendiente)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)")
                    .HasColumnName("SaldoPendiente");

                entity.Property(l => l.Estado)
                    .IsRequired()
                    .HasColumnName("Estado");

                entity.HasOne(l => l.Operacion)
                    .WithMany(o => o.Liquidaciones)
                    .HasForeignKey(l => l.OperacionId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(l => l.Detalle)
                    .WithOne(d => d.Liquidacion)
                    .HasForeignKey(d => d.LiquidacionId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(l => l.Pagos)
                    .WithOne(p => p.Liquidacion)
                    .HasForeignKey(p => p.LiquidacionId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(l => l.Factura)
                    .WithOne(f => f.Liquidacion)
                    .HasForeignKey<Factura>(f => f.LiquidacionId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Configuración de la tabla detalle liquidación
            modelBuilder.Entity<DetalleLiquidacion>(entity =>
            {
                entity.ToTable("DetallesLiquidacion");
                entity.HasKey(d => d.Id);

                entity.Property(d => d.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(d => d.Descripcion)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("Descripcion");

                entity.Property(d => d.Monto)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)")
                    .HasColumnName("Monto");

                entity.HasOne(d => d.Liquidacion)
                    .WithMany(l => l.Detalle)
                    .HasForeignKey(d => d.LiquidacionId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuración de la tabla Pago
            modelBuilder.Entity<Pago>(entity =>
            {
                entity.ToTable("Pagos");
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(p => p.FechaPago)
                    .IsRequired()
                    .HasColumnName("FechaPago");

                entity.Property(p => p.MontoPagado)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)")
                    .HasColumnName("MontoPagado");

                entity.Property(p => p.Estado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Estado");

                entity.Property(p => p.RutaComprobante)
                    .HasMaxLength(500)
                    .HasColumnName("RutaComprobante");

                entity.Property(p => p.IdTransaccion)
                    .HasMaxLength(100)
                    .HasColumnName("IdTransaccion");

                entity.Property(p => p.Tipo)
                    .IsRequired()
                    .HasColumnName("Tipo");

                entity.HasOne(p => p.Liquidacion)
                    .WithMany(l => l.Pagos)
                    .HasForeignKey(p => p.LiquidacionId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(p => p.Validacion)
                    .WithOne(v => v.Pago)
                    .HasForeignKey<ValidacionPago>(v => v.PagoId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Configuración de la tabla ValidacionPago
            modelBuilder.Entity<ValidacionPago>(entity =>
            {
                entity.ToTable("ValidacionesPago");
                entity.HasKey(v => v.Id);

                entity.Property(v => v.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(v => v.FechaValidacion)
                    .IsRequired()
                    .HasColumnName("FechaValidacion")
                    .HasDefaultValue(DateTime.Now);

                entity.Property(v => v.Aprobado)
                    .IsRequired()
                    .HasColumnName("Aprobado");

                entity.Property(v => v.MotivoRechazo)
                    .HasMaxLength(500)
                    .HasColumnName("MotivoRechazo");

                entity.HasOne(v => v.UsuarioValidacion)
                    .WithMany()
                    .HasForeignKey(v => v.UsuarioValidacionId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(v => v.Pago)
                    .WithOne(p => p.Validacion)
                    .HasForeignKey<ValidacionPago>(v => v.PagoId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuración de la tabla Factura
            modelBuilder.Entity<Factura>(entity =>
            {
                entity.ToTable("Facturas");
                entity.HasKey(f => f.Id);

                entity.Property(f => f.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(f => f.RutaArchivo)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("RutaArchivo");

                entity.Property(f => f.FechaCarga)
                    .IsRequired()
                    .HasColumnName("FechaCarga")
                    .HasDefaultValue(DateTime.Now);

                entity.HasOne(f => f.Liquidacion)
                    .WithOne(l => l.Factura)
                    .HasForeignKey<Factura>(f => f.LiquidacionId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuración de la tabla Asunto
            modelBuilder.Entity<Asunto>(entity =>
            {
                entity.ToTable("Asuntos");
                entity.HasKey(a => a.Id);

                entity.Property(a => a.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(a => a.Nomenclatura)
                    .IsRequired()
                    .HasColumnName("Nomenclatura");

                entity.Property(a => a.NombreCliente)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("NombreCliente");

                entity.Property(a => a.NroDua)
                    .HasColumnName("NroDua");

                entity.Property(a => a.NroCarpeta)
                    .HasColumnName("NroCarpeta");
            });

            //Configuración de la tabla TipoComunicacion
            modelBuilder.Entity<TipoComunicacion>(entity =>
            {
                entity.ToTable("TiposComunicacion");
                entity.HasKey(t => t.Id);

                entity.Property(t => t.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(t => t.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("Descripcion");

                entity.Property(t => t.Contenido)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .HasColumnName("Contenido");

                entity.HasOne(t => t.Asunto)
                    .WithMany()
                    .HasForeignKey(t => t.AsuntoId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // ConfiguraConfiguración de la tabla Comunicación
            modelBuilder.Entity<Comunicacion>(entity =>
            {
                entity.ToTable("Comunicaciones");
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(c => c.Contenido)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .HasColumnName("Contenido");

                entity.Property(c => c.FechaEnvio)
                    .IsRequired()
                    .HasColumnName("FechaEnvio")
                    .HasDefaultValue(DateTime.Now);

                entity.Property(c => c.Enviado)
                    .IsRequired()
                    .HasColumnName("Enviado")
                    .HasDefaultValue(false);

                entity.HasOne(c => c.UsuarioEnvio)
                    .WithMany()
                    .HasForeignKey(c => c.UsuarioEnvioId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(c => c.Operacion)
                    .WithMany(o => o.Comunicaciones)
                    .HasForeignKey(c => c.OperacionId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(c => c.TipoComunicacion)
                    .WithMany()
                    .HasForeignKey(c => c.TipoComunicacionId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(c => c.Asunto)
                    .WithMany()
                    .HasForeignKey(c => c.AsuntoId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Aplicar Seed Data
            modelBuilder.ConfigureSeedData();
        }

    }
}
