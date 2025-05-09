using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class SetNullDepartmentDelet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_DeanOffices_DeanOfficeId",
                table: "Departments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5aa07e78-2424-437a-b75a-8f283e8f1caa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "856f353e-39bd-416c-a4c0-f38ecb4d1976");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecd7d9d7-2f51-4a86-90a6-ce9be95969b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5f9a869-adc3-4f84-9b53-3864d00daac5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6d85ae4-f6bf-4bb9-97e6-42fb9405892b");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_DeanOffices_DeanOfficeId",
                table: "Departments",
                column: "DeanOfficeId",
                principalTable: "DeanOffices",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_DeanOffices_DeanOfficeId",
                table: "Departments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5aa07e78-2424-437a-b75a-8f283e8f1caa", null, "Методист", "МЕТОДИСТ" },
                    { "856f353e-39bd-416c-a4c0-f38ecb4d1976", null, "Инженер коммуниционного  центра", "ИНЖЕНЕР КОММУНИЦИОННОГО ЦЕНТРА" },
                    { "ecd7d9d7-2f51-4a86-90a6-ce9be95969b0", null, "Проректор", "ПРОРЕКТОР" },
                    { "f5f9a869-adc3-4f84-9b53-3864d00daac5", null, "admin", "ADMIN" },
                    { "f6d85ae4-f6bf-4bb9-97e6-42fb9405892b", null, "Ответственный за склад", "ОТВЕТСТВЕННЫЙ ЗА СКЛАД" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_DeanOffices_DeanOfficeId",
                table: "Departments",
                column: "DeanOfficeId",
                principalTable: "DeanOffices",
                principalColumn: "Id");
        }
    }
}
