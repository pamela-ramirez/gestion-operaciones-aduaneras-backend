using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class RutComoValueObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clientes_RUT_Unique",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "RUT",
                table: "Usuarios",
                newName: "Rut");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaValidacion",
                table: "ValidacionesPago",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 7, 21, 54, 5, 157, DateTimeKind.Local).AddTicks(1260),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 7, 21, 39, 28, 4, DateTimeKind.Local).AddTicks(330));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 7, 21, 54, 5, 128, DateTimeKind.Local).AddTicks(6096),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 7, 21, 39, 27, 989, DateTimeKind.Local).AddTicks(8489));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaRegistro",
                table: "Operaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 7, 21, 54, 5, 145, DateTimeKind.Local).AddTicks(9927),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 7, 21, 39, 27, 994, DateTimeKind.Local).AddTicks(2162));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCarga",
                table: "Facturas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 7, 21, 54, 5, 158, DateTimeKind.Local).AddTicks(4859),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 7, 21, 39, 28, 5, DateTimeKind.Local).AddTicks(3907));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCarga",
                table: "Documentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 7, 21, 54, 5, 150, DateTimeKind.Local).AddTicks(5273),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 7, 21, 39, 27, 998, DateTimeKind.Local).AddTicks(2842));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaEnvio",
                table: "Comunicaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 7, 21, 54, 5, 160, DateTimeKind.Local).AddTicks(8301),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 7, 21, 39, 28, 7, DateTimeKind.Local).AddTicks(1004));

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_RUT_Unique",
                table: "Usuarios",
                column: "Rut",
                unique: true,
                filter: "[Rut] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clientes_RUT_Unique",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "Rut",
                table: "Usuarios",
                newName: "RUT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaValidacion",
                table: "ValidacionesPago",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 7, 21, 39, 28, 4, DateTimeKind.Local).AddTicks(330),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 7, 21, 54, 5, 157, DateTimeKind.Local).AddTicks(1260));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 7, 21, 39, 27, 989, DateTimeKind.Local).AddTicks(8489),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 7, 21, 54, 5, 128, DateTimeKind.Local).AddTicks(6096));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaRegistro",
                table: "Operaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 7, 21, 39, 27, 994, DateTimeKind.Local).AddTicks(2162),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 7, 21, 54, 5, 145, DateTimeKind.Local).AddTicks(9927));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCarga",
                table: "Facturas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 7, 21, 39, 28, 5, DateTimeKind.Local).AddTicks(3907),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 7, 21, 54, 5, 158, DateTimeKind.Local).AddTicks(4859));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCarga",
                table: "Documentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 7, 21, 39, 27, 998, DateTimeKind.Local).AddTicks(2842),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 7, 21, 54, 5, 150, DateTimeKind.Local).AddTicks(5273));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaEnvio",
                table: "Comunicaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 7, 21, 39, 28, 7, DateTimeKind.Local).AddTicks(1004),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 7, 21, 54, 5, 160, DateTimeKind.Local).AddTicks(8301));

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_RUT_Unique",
                table: "Usuarios",
                column: "RUT",
                unique: true,
                filter: "[RUT] IS NOT NULL");
        }
    }
}
