using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bugeto_Store.Presistence.Migrations
{
    /// <inheritdoc />
    public partial class rolesseedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2025, 8, 25, 9, 23, 23, 490, DateTimeKind.Local).AddTicks(5773));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2025, 8, 25, 9, 23, 23, 491, DateTimeKind.Local).AddTicks(6577));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2025, 8, 25, 9, 23, 23, 491, DateTimeKind.Local).AddTicks(6643));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2025, 8, 23, 18, 51, 24, 977, DateTimeKind.Local).AddTicks(4003));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2025, 8, 23, 18, 51, 24, 978, DateTimeKind.Local).AddTicks(6234));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2025, 8, 23, 18, 51, 24, 978, DateTimeKind.Local).AddTicks(6312));
        }
    }
}
