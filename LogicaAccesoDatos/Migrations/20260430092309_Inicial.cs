using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaValidacion",
                table: "ValidacionesPago",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 30, 6, 23, 7, 724, DateTimeKind.Local).AddTicks(5008),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 4, 30, 5, 0, 32, 951, DateTimeKind.Local).AddTicks(2350));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaRegistro",
                table: "Operaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 30, 6, 23, 7, 717, DateTimeKind.Local).AddTicks(586),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 4, 30, 5, 0, 32, 946, DateTimeKind.Local).AddTicks(8852));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCarga",
                table: "Facturas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 30, 6, 23, 7, 724, DateTimeKind.Local).AddTicks(8990),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 4, 30, 5, 0, 32, 951, DateTimeKind.Local).AddTicks(7875));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCarga",
                table: "Documentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 30, 6, 23, 7, 720, DateTimeKind.Local).AddTicks(4973),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 4, 30, 5, 0, 32, 949, DateTimeKind.Local).AddTicks(995));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaEnvio",
                table: "Comunicaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 30, 6, 23, 7, 725, DateTimeKind.Local).AddTicks(5863),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 4, 30, 5, 0, 32, 952, DateTimeKind.Local).AddTicks(7149));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaValidacion",
                table: "ValidacionesPago",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 30, 5, 0, 32, 951, DateTimeKind.Local).AddTicks(2350),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 4, 30, 6, 23, 7, 724, DateTimeKind.Local).AddTicks(5008));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaRegistro",
                table: "Operaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 30, 5, 0, 32, 946, DateTimeKind.Local).AddTicks(8852),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 4, 30, 6, 23, 7, 717, DateTimeKind.Local).AddTicks(586));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCarga",
                table: "Facturas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 30, 5, 0, 32, 951, DateTimeKind.Local).AddTicks(7875),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 4, 30, 6, 23, 7, 724, DateTimeKind.Local).AddTicks(8990));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCarga",
                table: "Documentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 30, 5, 0, 32, 949, DateTimeKind.Local).AddTicks(995),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 4, 30, 6, 23, 7, 720, DateTimeKind.Local).AddTicks(4973));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaEnvio",
                table: "Comunicaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 30, 5, 0, 32, 952, DateTimeKind.Local).AddTicks(7149),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 4, 30, 6, 23, 7, 725, DateTimeKind.Local).AddTicks(5863));
        }
    }
}
