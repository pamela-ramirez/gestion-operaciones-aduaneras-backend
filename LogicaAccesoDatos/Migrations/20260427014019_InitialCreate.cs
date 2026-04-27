using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asuntos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nomenclatura = table.Column<int>(type: "int", nullable: false),
                    NombreCliente = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NroDua = table.Column<int>(type: "int", nullable: true),
                    NroCarpeta = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asuntos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRol = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposConocimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposConocimiento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposOperacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposOperacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposComunicacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Contenido = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    AsuntoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposComunicacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TiposComunicacion_Asuntos_AsuntoId",
                        column: x => x.AsuntoId,
                        principalTable: "Asuntos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<int>(type: "int", nullable: false),
                    RUT = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Operaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NroCarpeta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2026, 4, 26, 22, 40, 18, 715, DateTimeKind.Local).AddTicks(5875)),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    TipoOperacionId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    NroDua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoConocimientoId = table.Column<int>(type: "int", nullable: true),
                    NroConocimiento = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operaciones_TiposConocimiento_TipoConocimientoId",
                        column: x => x.TipoConocimientoId,
                        principalTable: "TiposConocimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Operaciones_TiposOperacion_TipoOperacionId",
                        column: x => x.TipoOperacionId,
                        principalTable: "TiposOperacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operaciones_Usuarios_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comunicaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contenido = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    FechaEnvio = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2026, 4, 26, 22, 40, 18, 725, DateTimeKind.Local).AddTicks(880)),
                    Enviado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UsuarioEnvioId = table.Column<int>(type: "int", nullable: false),
                    OperacionId = table.Column<int>(type: "int", nullable: true),
                    TipoComunicacionId = table.Column<int>(type: "int", nullable: false),
                    AsuntoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comunicaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comunicaciones_Asuntos_AsuntoId",
                        column: x => x.AsuntoId,
                        principalTable: "Asuntos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comunicaciones_Operaciones_OperacionId",
                        column: x => x.OperacionId,
                        principalTable: "Operaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Comunicaciones_TiposComunicacion_TipoComunicacionId",
                        column: x => x.TipoComunicacionId,
                        principalTable: "TiposComunicacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comunicaciones_Usuarios_UsuarioEnvioId",
                        column: x => x.UsuarioEnvioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RutaArchivo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Formato = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FechaCarga = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2026, 4, 26, 22, 40, 18, 718, DateTimeKind.Local).AddTicks(5407)),
                    OperacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documentos_Operaciones_OperacionId",
                        column: x => x.OperacionId,
                        principalTable: "Operaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Liquidaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaEnvio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaVenc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MontoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaldoPendiente = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    OperacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liquidaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Liquidaciones_Operaciones_OperacionId",
                        column: x => x.OperacionId,
                        principalTable: "Operaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallesLiquidacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LiquidacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesLiquidacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallesLiquidacion_Liquidaciones_LiquidacionId",
                        column: x => x.LiquidacionId,
                        principalTable: "Liquidaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RutaArchivo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FechaCarga = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2026, 4, 26, 22, 40, 18, 723, DateTimeKind.Local).AddTicks(8762)),
                    LiquidacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facturas_Liquidaciones_LiquidacionId",
                        column: x => x.LiquidacionId,
                        principalTable: "Liquidaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MontoPagado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RutaComprobante = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IdTransaccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    LiquidacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagos_Liquidaciones_LiquidacionId",
                        column: x => x.LiquidacionId,
                        principalTable: "Liquidaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ValidacionesPago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaValidacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2026, 4, 26, 22, 40, 18, 722, DateTimeKind.Local).AddTicks(8959)),
                    Aprobado = table.Column<bool>(type: "bit", nullable: false),
                    MotivoRechazo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UsuarioValidacionId = table.Column<int>(type: "int", nullable: false),
                    PagoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidacionesPago", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValidacionesPago_Pagos_PagoId",
                        column: x => x.PagoId,
                        principalTable: "Pagos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ValidacionesPago_Usuarios_UsuarioValidacionId",
                        column: x => x.UsuarioValidacionId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "NombreRol" },
                values: new object[,]
                {
                    { 1, "Despachante" },
                    { 2, "Cliente" },
                    { 3, "Asistente" }
                });

            migrationBuilder.InsertData(
                table: "TiposConocimiento",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Conocimiento de Embarque Marítimo" },
                    { 2, "Guía Aérea" },
                    { 3, "Carta de Porte Terrestre" },
                    { 4, "Declaración de Tránsito" }
                });

            migrationBuilder.InsertData(
                table: "TiposOperacion",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Importación" },
                    { 2, "Exportación" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comunicaciones_AsuntoId",
                table: "Comunicaciones",
                column: "AsuntoId");

            migrationBuilder.CreateIndex(
                name: "IX_Comunicaciones_OperacionId",
                table: "Comunicaciones",
                column: "OperacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Comunicaciones_TipoComunicacionId",
                table: "Comunicaciones",
                column: "TipoComunicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Comunicaciones_UsuarioEnvioId",
                table: "Comunicaciones",
                column: "UsuarioEnvioId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesLiquidacion_LiquidacionId",
                table: "DetallesLiquidacion",
                column: "LiquidacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_OperacionId",
                table: "Documentos",
                column: "OperacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_LiquidacionId",
                table: "Facturas",
                column: "LiquidacionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Liquidaciones_OperacionId",
                table: "Liquidaciones",
                column: "OperacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Operaciones_ClienteId",
                table: "Operaciones",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Operaciones_NroCarpeta_Unique",
                table: "Operaciones",
                column: "NroCarpeta",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Operaciones_TipoConocimientoId",
                table: "Operaciones",
                column: "TipoConocimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Operaciones_TipoOperacionId",
                table: "Operaciones",
                column: "TipoOperacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_LiquidacionId",
                table: "Pagos",
                column: "LiquidacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_NombreRol_Unique",
                table: "Roles",
                column: "NombreRol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TiposComunicacion_AsuntoId",
                table: "TiposComunicacion",
                column: "AsuntoId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposConocimiento_Descripcion_Unique",
                table: "TiposConocimiento",
                column: "Descripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TiposOperacion_Descripcion_Unique",
                table: "TiposOperacion",
                column: "Descripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_RUT_Unique",
                table: "Usuarios",
                column: "RUT",
                unique: true,
                filter: "[RUT] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Despachantes_RUT_Unique",
                table: "Usuarios",
                column: "RUT",
                unique: true,
                filter: "[RUT] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email_Unique",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_ValidacionesPago_PagoId",
                table: "ValidacionesPago",
                column: "PagoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ValidacionesPago_UsuarioValidacionId",
                table: "ValidacionesPago",
                column: "UsuarioValidacionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comunicaciones");

            migrationBuilder.DropTable(
                name: "DetallesLiquidacion");

            migrationBuilder.DropTable(
                name: "Documentos");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "ValidacionesPago");

            migrationBuilder.DropTable(
                name: "TiposComunicacion");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Asuntos");

            migrationBuilder.DropTable(
                name: "Liquidaciones");

            migrationBuilder.DropTable(
                name: "Operaciones");

            migrationBuilder.DropTable(
                name: "TiposConocimiento");

            migrationBuilder.DropTable(
                name: "TiposOperacion");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
