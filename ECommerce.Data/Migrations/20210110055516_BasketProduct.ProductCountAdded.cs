using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Data.Migrations
{
    public partial class BasketProductProductCountAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductCount",
                table: "BasketProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreateDate" },
                values: new object[] { "fc417fae-af95-4760-b9d6-716b35e3ec04", new DateTime(2021, 1, 10, 8, 55, 14, 58, DateTimeKind.Local).AddTicks(1732) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreateDate" },
                values: new object[] { "c7edc812-8670-4d92-8494-9cce2d2ce193", new DateTime(2021, 1, 10, 8, 55, 14, 59, DateTimeKind.Local).AddTicks(3719) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 1, 10, 8, 55, 14, 62, DateTimeKind.Local).AddTicks(1871));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCount",
                table: "BasketProducts");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreateDate" },
                values: new object[] { "f4b98e45-effe-438d-926f-52c6159eae9f", new DateTime(2021, 1, 9, 21, 10, 14, 915, DateTimeKind.Local).AddTicks(5308) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreateDate" },
                values: new object[] { "e0c9dde2-ea20-48eb-9804-41a4924cc2c9", new DateTime(2021, 1, 9, 21, 10, 14, 916, DateTimeKind.Local).AddTicks(3387) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 1, 9, 21, 10, 14, 918, DateTimeKind.Local).AddTicks(9219));
        }
    }
}
