using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class EditRepairWithWriteDown : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfWriteDowns",
                table: "WriteDowns",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "WriteDowns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfRepairComputer",
                table: "RepairComputers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AlterColumn<string>(
                name: "InventoryNumber",
                table: "ComputerPassports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

           

            migrationBuilder.CreateIndex(
                name: "IX_WriteDowns_WarehouseId",
                table: "WriteDowns",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_WriteDowns_Warehouses_WarehouseId",
                table: "WriteDowns",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WriteDowns_Warehouses_WarehouseId",
                table: "WriteDowns");

            migrationBuilder.DropIndex(
                name: "IX_WriteDowns_WarehouseId",
                table: "WriteDowns");

            

            migrationBuilder.DropColumn(
                name: "DateOfWriteDowns",
                table: "WriteDowns");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "WriteDowns");

            migrationBuilder.DropColumn(
                name: "DateOfRepairComputer",
                table: "RepairComputers");

            migrationBuilder.AlterColumn<string>(
                name: "InventoryNumber",
                table: "ComputerPassports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
