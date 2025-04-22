using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class addRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a9d5403c-0278-4aec-ade0-4398c4604ed3", null, "Инженер коммуниционного  центра", "ИНЖЕНЕР КОММУНИЦИОННОГО ЦЕНТРА" },
                    { "b522e1a6-1dbd-47cb-a14d-5c6e549384dc", null, "Проректор", "ПРОРЕКТОР" },
                    { "c7c8b301-38ed-4141-a58b-118c38955d4f", null, "Ответственный за склад", "ОТВЕТСТВЕННЫЙ ЗА СКЛАД" },
                    { "d2f1bb0c-3fb6-4f8a-a20b-78827cc31554", null, "admin", "ADMIN" },
                    { "d98ba1ab-78fa-43db-b14d-0fa315c7f1f3", null, "Методист", "МЕТОДИСТ" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9d5403c-0278-4aec-ade0-4398c4604ed3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b522e1a6-1dbd-47cb-a14d-5c6e549384dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7c8b301-38ed-4141-a58b-118c38955d4f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2f1bb0c-3fb6-4f8a-a20b-78827cc31554");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d98ba1ab-78fa-43db-b14d-0fa315c7f1f3");
        }
    }
}
