using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bugeto_Store.Presistence.Migrations
{
    /// <inheritdoc />
    public partial class categories1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "InsertTime", "IsRemoved", "Name", "RemovedTime", "UpdateTime" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 8, 23, 17, 10, 25, 579, DateTimeKind.Local).AddTicks(6635), false, "Admin", null, null },
                    { 2L, new DateTime(2025, 8, 23, 17, 10, 25, 581, DateTimeKind.Local).AddTicks(816), false, "Operator", null, null },
                    { 3L, new DateTime(2025, 8, 23, 17, 10, 25, 581, DateTimeKind.Local).AddTicks(888), false, "Customer", null, null }
                });
        }
    }
}
