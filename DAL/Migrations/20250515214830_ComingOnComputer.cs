using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ComingOnComputer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComputerPassports_Comings_ComingId",
                table: "ComputerPassports");

            migrationBuilder.DropIndex(
                name: "IX_ComputerPassports_ComingId",
                table: "ComputerPassports");

            migrationBuilder.DropColumn(
                name: "ComingId",
                table: "ComputerPassports");

            migrationBuilder.AddColumn<int>(
                name: "ComingId",
                table: "Computers",
                type: "int",
                nullable: true);


            migrationBuilder.CreateIndex(
                name: "IX_Computers_ComingId",
                table: "Computers",
                column: "ComingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Comings_ComingId",
                table: "Computers",
                column: "ComingId",
                principalTable: "Comings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Comings_ComingId",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_ComingId",
                table: "Computers");           

            migrationBuilder.DropColumn(
                name: "ComingId",
                table: "Computers");

            migrationBuilder.AddColumn<int>(
                name: "ComingId",
                table: "ComputerPassports",
                type: "int",
                nullable: false,
                defaultValue: 0);
         

            migrationBuilder.CreateIndex(
                name: "IX_ComputerPassports_ComingId",
                table: "ComputerPassports",
                column: "ComingId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComputerPassports_Comings_ComingId",
                table: "ComputerPassports",
                column: "ComingId",
                principalTable: "Comings",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
