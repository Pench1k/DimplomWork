using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2ebccd46-7b56-454a-a1d9-a9fcc53d637d", null, "Инженер коммуниционного  центра", "ИНЖЕНЕР КОММУНИЦИОННОГО ЦЕНТРА" },
                    { "8f45df51-3b0d-4abc-bd95-d06c0a10fbfd", null, "Ответственный за склад", "ОТВЕТСТВЕННЫЙ ЗА СКЛАД" },
                    { "db11704c-0afc-4930-b0ee-371f40fb28a1", null, "admin", "ADMIN" },
                    { "dd423ab0-63ac-4f27-a0b9-9dd05cfcdf02", null, "Проректор", "ПРОРЕКТОР" },
                    { "eb749a53-feac-48f6-b160-d9ca796b01c9", null, "Методист", "МЕТОДИСТ" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ebccd46-7b56-454a-a1d9-a9fcc53d637d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f45df51-3b0d-4abc-bd95-d06c0a10fbfd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db11704c-0afc-4930-b0ee-371f40fb28a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd423ab0-63ac-4f27-a0b9-9dd05cfcdf02");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb749a53-feac-48f6-b160-d9ca796b01c9");
        }
    }
}
