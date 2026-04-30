using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class arreglarPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaValidacion",
                table: "ValidacionesPago",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 30, 6, 27, 28, 317, DateTimeKind.Local).AddTicks(572),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 4, 30, 6, 23, 7, 724, DateTimeKind.Local).AddTicks(5008));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaRegistro",
                table: "Operaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 30, 6, 27, 28, 310, DateTimeKind.Local).AddTicks(7555),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 4, 30, 6, 23, 7, 717, DateTimeKind.Local).AddTicks(586));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCarga",
                table: "Facturas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 30, 6, 27, 28, 317, DateTimeKind.Local).AddTicks(6493),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 4, 30, 6, 23, 7, 724, DateTimeKind.Local).AddTicks(8990));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCarga",
                table: "Documentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 30, 6, 27, 28, 313, DateTimeKind.Local).AddTicks(7671),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 4, 30, 6, 23, 7, 720, DateTimeKind.Local).AddTicks(4973));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaEnvio",
                table: "Comunicaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 30, 6, 27, 28, 318, DateTimeKind.Local).AddTicks(5086),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 4, 30, 6, 23, 7, 725, DateTimeKind.Local).AddTicks(5863));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaValidacion",
                table: "ValidacionesPago",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 30, 6, 23, 7, 724, DateTimeKind.Local).AddTicks(5008),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 4, 30, 6, 27, 28, 317, DateTimeKind.Local).AddTicks(572));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaRegistro",
                table: "Operaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 30, 6, 23, 7, 717, DateTimeKind.Local).AddTicks(586),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 4, 30, 6, 27, 28, 310, DateTimeKind.Local).AddTicks(7555));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCarga",
                table: "Facturas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 30, 6, 23, 7, 724, DateTimeKind.Local).AddTicks(8990),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 4, 30, 6, 27, 28, 317, DateTimeKind.Local).AddTicks(6493));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCarga",
                table: "Documentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 30, 6, 23, 7, 720, DateTimeKind.Local).AddTicks(4973),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 4, 30, 6, 27, 28, 313, DateTimeKind.Local).AddTicks(7671));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaEnvio",
                table: "Comunicaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 30, 6, 23, 7, 725, DateTimeKind.Local).AddTicks(5863),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 4, 30, 6, 27, 28, 318, DateTimeKind.Local).AddTicks(5086));
        }
    }
}
