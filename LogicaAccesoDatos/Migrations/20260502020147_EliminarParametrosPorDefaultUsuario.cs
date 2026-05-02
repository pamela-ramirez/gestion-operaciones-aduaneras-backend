using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class EliminarParametrosPorDefaultUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaValidacion",
                table: "ValidacionesPago",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 1, 23, 1, 47, 320, DateTimeKind.Local).AddTicks(4379),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 1, 21, 58, 19, 699, DateTimeKind.Local).AddTicks(476));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 1, 23, 1, 47, 318, DateTimeKind.Local).AddTicks(3980),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 1, 21, 58, 19, 682, DateTimeKind.Local).AddTicks(8463));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaRegistro",
                table: "Operaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 1, 23, 1, 47, 318, DateTimeKind.Local).AddTicks(9011),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 1, 21, 58, 19, 694, DateTimeKind.Local).AddTicks(1279));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCarga",
                table: "Facturas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 1, 23, 1, 47, 320, DateTimeKind.Local).AddTicks(6505),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 1, 21, 58, 19, 699, DateTimeKind.Local).AddTicks(7597));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCarga",
                table: "Documentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 1, 23, 1, 47, 319, DateTimeKind.Local).AddTicks(6394),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 1, 21, 58, 19, 696, DateTimeKind.Local).AddTicks(6672));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaEnvio",
                table: "Comunicaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 1, 23, 1, 47, 320, DateTimeKind.Local).AddTicks(9613),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 1, 21, 58, 19, 700, DateTimeKind.Local).AddTicks(6308));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaValidacion",
                table: "ValidacionesPago",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 1, 21, 58, 19, 699, DateTimeKind.Local).AddTicks(476),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 1, 23, 1, 47, 320, DateTimeKind.Local).AddTicks(4379));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 1, 21, 58, 19, 682, DateTimeKind.Local).AddTicks(8463),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 1, 23, 1, 47, 318, DateTimeKind.Local).AddTicks(3980));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaRegistro",
                table: "Operaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 1, 21, 58, 19, 694, DateTimeKind.Local).AddTicks(1279),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 1, 23, 1, 47, 318, DateTimeKind.Local).AddTicks(9011));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCarga",
                table: "Facturas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 1, 21, 58, 19, 699, DateTimeKind.Local).AddTicks(7597),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 1, 23, 1, 47, 320, DateTimeKind.Local).AddTicks(6505));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCarga",
                table: "Documentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 1, 21, 58, 19, 696, DateTimeKind.Local).AddTicks(6672),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 1, 23, 1, 47, 319, DateTimeKind.Local).AddTicks(6394));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaEnvio",
                table: "Comunicaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 1, 21, 58, 19, 700, DateTimeKind.Local).AddTicks(6308),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 1, 23, 1, 47, 320, DateTimeKind.Local).AddTicks(9613));
        }
    }
}
