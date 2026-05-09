using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class PrecargaClientesYDespachantes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaValidacion",
                table: "ValidacionesPago",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 9, 19, 7, 46, 330, DateTimeKind.Local).AddTicks(4478),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 9, 17, 48, 51, 688, DateTimeKind.Local).AddTicks(5324));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 9, 19, 7, 46, 322, DateTimeKind.Local).AddTicks(8722),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 9, 17, 48, 51, 681, DateTimeKind.Local).AddTicks(8329));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaRegistro",
                table: "Operaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 9, 19, 7, 46, 327, DateTimeKind.Local).AddTicks(6096),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 9, 17, 48, 51, 685, DateTimeKind.Local).AddTicks(9959));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCarga",
                table: "Facturas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 9, 19, 7, 46, 330, DateTimeKind.Local).AddTicks(7967),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 9, 17, 48, 51, 688, DateTimeKind.Local).AddTicks(8426));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCarga",
                table: "Documentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 9, 19, 7, 46, 329, DateTimeKind.Local).AddTicks(1444),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 9, 17, 48, 51, 687, DateTimeKind.Local).AddTicks(2062));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaEnvio",
                table: "Comunicaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 9, 19, 7, 46, 331, DateTimeKind.Local).AddTicks(2822),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 9, 17, 48, 51, 689, DateTimeKind.Local).AddTicks(3380));

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellido", "Codigo", "Discriminator", "Estado", "FechaCreacion", "Nombre", "RolId", "Email", "PasswordHash" },
                values: new object[,]
                {
                    { 10, "Fernández", "DESP-001", 2, "Activo", new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlos", 2, "carlos.fernandez@despacho.com.uy", "Despacho100!" },
                    { 11, "Ríos", "DESP-002", 2, "Activo", new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Valeria", 2, "valeria.rios@despacho.com.uy", "Despacho100!" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellido", "Direccion", "Discriminator", "Estado", "FechaCreacion", "Nombre", "RazonSocial", "RolId", "Telefono", "Email", "PasswordHash", "Rut" },
                values: new object[,]
                {
                    { 20, "González", "Av. 18 de Julio 1234, Montevideo", 1, "Activo", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martina", "González Import S.R.L.", 3, "099123456", "martina.gonzalez@gonzalezimport.com.uy", "Cliente100!", "21.234.567-8" },
                    { 21, "Álvarez", "Rambla República Argentina 2040, Montevideo", 1, "Activo", new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roberto", "Álvarez Exportaciones S.A.", 3, "098765432", "roberto.alvarez@alvarezexport.com.uy", "Cliente100!", "21.987.654-3" },
                    { 22, "Méndez", "Bulevar Artigas 1500, Montevideo", 1, "Activo", new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laura", "Méndez & Asociados Ltda.", 3, "091234567", "laura.mendez@mendezasociados.com.uy", "Cliente100!", "21.456.789-0" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaValidacion",
                table: "ValidacionesPago",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 9, 17, 48, 51, 688, DateTimeKind.Local).AddTicks(5324),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 9, 19, 7, 46, 330, DateTimeKind.Local).AddTicks(4478));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 9, 17, 48, 51, 681, DateTimeKind.Local).AddTicks(8329),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 9, 19, 7, 46, 322, DateTimeKind.Local).AddTicks(8722));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaRegistro",
                table: "Operaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 9, 17, 48, 51, 685, DateTimeKind.Local).AddTicks(9959),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 9, 19, 7, 46, 327, DateTimeKind.Local).AddTicks(6096));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCarga",
                table: "Facturas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 9, 17, 48, 51, 688, DateTimeKind.Local).AddTicks(8426),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 9, 19, 7, 46, 330, DateTimeKind.Local).AddTicks(7967));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCarga",
                table: "Documentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 9, 17, 48, 51, 687, DateTimeKind.Local).AddTicks(2062),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 9, 19, 7, 46, 329, DateTimeKind.Local).AddTicks(1444));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaEnvio",
                table: "Comunicaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 9, 17, 48, 51, 689, DateTimeKind.Local).AddTicks(3380),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 9, 19, 7, 46, 331, DateTimeKind.Local).AddTicks(2822));
        }
    }
}
