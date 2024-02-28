using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Condominio.Migrations
{
    /// <inheritdoc />
    public partial class alteracoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Resident",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 28, 17, 46, 0, 782, DateTimeKind.Local).AddTicks(8712),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 31, 9, 58, 53, 124, DateTimeKind.Local).AddTicks(3022));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Resident",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 31, 9, 58, 53, 124, DateTimeKind.Local).AddTicks(3022),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 28, 17, 46, 0, 782, DateTimeKind.Local).AddTicks(8712));
        }
    }
}
