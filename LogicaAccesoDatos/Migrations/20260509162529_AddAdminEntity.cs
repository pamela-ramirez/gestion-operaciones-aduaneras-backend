using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaValidacion",
                table: "ValidacionesPago",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 9, 13, 25, 28, 187, DateTimeKind.Local).AddTicks(7631),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 9, 12, 56, 16, 952, DateTimeKind.Local).AddTicks(1750));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 9, 13, 25, 28, 179, DateTimeKind.Local).AddTicks(9947),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 9, 12, 56, 16, 948, DateTimeKind.Local).AddTicks(3808));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaRegistro",
                table: "Operaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 9, 13, 25, 28, 183, DateTimeKind.Local).AddTicks(8595),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 9, 12, 56, 16, 950, DateTimeKind.Local).AddTicks(6452));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCarga",
                table: "Facturas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 9, 13, 25, 28, 188, DateTimeKind.Local).AddTicks(5249),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 9, 12, 56, 16, 952, DateTimeKind.Local).AddTicks(3930));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCarga",
                table: "Documentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 9, 13, 25, 28, 185, DateTimeKind.Local).AddTicks(1454),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 9, 12, 56, 16, 951, DateTimeKind.Local).AddTicks(3869));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaEnvio",
                table: "Comunicaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 9, 13, 25, 28, 189, DateTimeKind.Local).AddTicks(4308),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 9, 12, 56, 16, 952, DateTimeKind.Local).AddTicks(9948));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaValidacion",
                table: "ValidacionesPago",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 9, 12, 56, 16, 952, DateTimeKind.Local).AddTicks(1750),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 9, 13, 25, 28, 187, DateTimeKind.Local).AddTicks(7631));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 9, 12, 56, 16, 948, DateTimeKind.Local).AddTicks(3808),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 9, 13, 25, 28, 179, DateTimeKind.Local).AddTicks(9947));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaRegistro",
                table: "Operaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 9, 12, 56, 16, 950, DateTimeKind.Local).AddTicks(6452),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 9, 13, 25, 28, 183, DateTimeKind.Local).AddTicks(8595));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCarga",
                table: "Facturas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 9, 12, 56, 16, 952, DateTimeKind.Local).AddTicks(3930),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 9, 13, 25, 28, 188, DateTimeKind.Local).AddTicks(5249));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCarga",
                table: "Documentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 9, 12, 56, 16, 951, DateTimeKind.Local).AddTicks(3869),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 9, 13, 25, 28, 185, DateTimeKind.Local).AddTicks(1454));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaEnvio",
                table: "Comunicaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 9, 12, 56, 16, 952, DateTimeKind.Local).AddTicks(9948),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 9, 13, 25, 28, 189, DateTimeKind.Local).AddTicks(4308));
        }
    }
}
