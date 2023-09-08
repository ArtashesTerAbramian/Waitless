using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Waitless.DAL.Migrations
{
    public partial class error_seeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "error",
                columns: new[] { "id", "created_date", "is_deleted", "modify_date", "name" },
                values: new object[,]
                {
                    { 12L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "User with provided phone number already exists" },
                    { 13L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Your order already is in progress" },
                    { 14L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Cant Update order after 5 minutes from ordered time" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "error",
                keyColumn: "id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "error",
                keyColumn: "id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "error",
                keyColumn: "id",
                keyValue: 14L);
        }
    }
}
