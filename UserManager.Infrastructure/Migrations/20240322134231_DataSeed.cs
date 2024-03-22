using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Permissions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("489620d8-7daa-43be-a3a5-7ca0f989570e"), "Write" },
                    { new Guid("7f7cfde4-ed9f-4464-9085-356770e46cba"), "ReadWrite" },
                    { new Guid("82a42045-886c-4909-8338-2506519f9a8f"), "Read" },
                    { new Guid("cda20109-f4e2-424b-87d1-c0a529870376"), "Move" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("489620d8-7daa-43be-a3a5-7ca0f989570e"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("7f7cfde4-ed9f-4464-9085-356770e46cba"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("82a42045-886c-4909-8338-2506519f9a8f"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("cda20109-f4e2-424b-87d1-c0a529870376"));
        }
    }
}
