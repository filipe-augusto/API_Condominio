using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Condominio.Migrations
{
    /// <inheritdoc />
    public partial class addfieldHasGarageInUnit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasGarage",
                table: "Unit",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Resident",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 31, 9, 58, 53, 124, DateTimeKind.Local).AddTicks(3022),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 31, 9, 51, 29, 664, DateTimeKind.Local).AddTicks(8503));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasGarage",
                table: "Unit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Resident",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 31, 9, 51, 29, 664, DateTimeKind.Local).AddTicks(8503),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 31, 9, 58, 53, 124, DateTimeKind.Local).AddTicks(3022));
        }
    }
}
