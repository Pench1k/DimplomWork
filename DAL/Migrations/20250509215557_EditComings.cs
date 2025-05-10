using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class EditComings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comings_Warehouses_WarehouseId",
                table: "Comings");

            migrationBuilder.DropIndex(
                name: "IX_Comings_WarehouseId",
                table: "Comings");
          

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "Comings");

            migrationBuilder.AddColumn<int>(
                name: "ComingId",
                table: "ComputerPassports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfComing",
                table: "Comings",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<string>(
                name: "DocumentNumber",
                table: "Comings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Comings",
                type: "nvarchar(450)",
                nullable: true);
           

            migrationBuilder.CreateIndex(
                name: "IX_ComputerPassports_ComingId",
                table: "ComputerPassports",
                column: "ComingId");

            migrationBuilder.CreateIndex(
                name: "IX_Comings_UserId",
                table: "Comings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comings_AspNetUsers_UserId",
                table: "Comings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ComputerPassports_Comings_ComingId",
                table: "ComputerPassports",
                column: "ComingId",
                principalTable: "Comings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comings_AspNetUsers_UserId",
                table: "Comings");

            migrationBuilder.DropForeignKey(
                name: "FK_ComputerPassports_Comings_ComingId",
                table: "ComputerPassports");

            migrationBuilder.DropIndex(
                name: "IX_ComputerPassports_ComingId",
                table: "ComputerPassports");

            migrationBuilder.DropIndex(
                name: "IX_Comings_UserId",
                table: "Comings");

            migrationBuilder.DropColumn(
                name: "ComingId",
                table: "ComputerPassports");

            migrationBuilder.DropColumn(
                name: "DocumentNumber",
                table: "Comings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comings");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfComing",
                table: "Comings",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "Comings",
                type: "int",
                nullable: true);
        
            migrationBuilder.CreateIndex(
                name: "IX_Comings_WarehouseId",
                table: "Comings",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comings_Warehouses_WarehouseId",
                table: "Comings",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id");
        }
    }
}
