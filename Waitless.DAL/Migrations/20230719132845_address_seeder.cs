using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Waitless.DAL.Migrations
{
    public partial class address_seeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "address",
                columns: new[] { "id", "city_id", "created_date", "is_deleted", "modify_date", "postal_code" },
                values: new object[] { 1L, 1L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "0002" });

            migrationBuilder.InsertData(
                table: "address_translation",
                columns: new[] { "id", "address_id", "created_date", "is_deleted", "language_id", "modify_date", "street" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "21 Mesrop Mashtots Ave" },
                    { 2L, 1L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "пр. Месропа Маштоца 21" },
                    { 3L, 1L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "21 Մեսրոպ Մաշտոց պողոտա" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "address_translation",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "address_translation",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "address_translation",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "address",
                keyColumn: "id",
                keyValue: 1L);
        }
    }
}
