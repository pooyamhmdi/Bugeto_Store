using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bugeto_Store.Presistence.Migrations
{
    /// <inheritdoc />
    public partial class seedDataRoles2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2025, 8, 23, 18, 45, 23, 686, DateTimeKind.Local).AddTicks(6649));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2025, 8, 23, 18, 45, 23, 687, DateTimeKind.Local).AddTicks(7185));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2025, 8, 23, 18, 45, 23, 687, DateTimeKind.Local).AddTicks(7249));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2025, 8, 23, 18, 40, 14, 110, DateTimeKind.Local).AddTicks(6353));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2025, 8, 23, 18, 40, 14, 111, DateTimeKind.Local).AddTicks(9953));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2025, 8, 23, 18, 40, 14, 112, DateTimeKind.Local).AddTicks(25));
        }
    }
}
