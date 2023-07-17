using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Waitless.DAL.Migrations
{
    public partial class beverage_type_seeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "beverage_type_id",
                table: "beverage_type_translation",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "beverage_type",
                columns: new[] { "id", "created_date", "is_deleted", "modify_date" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 3L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 4L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 5L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "beverage_type_translation",
                columns: new[] { "id", "beverage_type_id", "created_date", "is_deleted", "language_id", "modify_date", "name" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Coffee" },
                    { 2L, 1L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Кофе" },
                    { 3L, 1L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Սուրճ" },
                    { 4L, 2L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Tea" },
                    { 5L, 2L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Чай" },
                    { 6L, 2L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Թեյ" },
                    { 7L, 3L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Smoothie" },
                    { 8L, 3L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Смузи" },
                    { 9L, 3L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Սմուզի" },
                    { 10L, 4L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Lemonade" },
                    { 11L, 4L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Лимонад" },
                    { 12L, 4L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Լիմոնադ" },
                    { 13L, 5L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Juice" },
                    { 14L, 5L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Сок" },
                    { 15L, 5L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ջուս" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "beverage_type_translation",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "beverage_type_translation",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "beverage_type_translation",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "beverage_type_translation",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "beverage_type_translation",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "beverage_type_translation",
                keyColumn: "id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "beverage_type_translation",
                keyColumn: "id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "beverage_type_translation",
                keyColumn: "id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "beverage_type_translation",
                keyColumn: "id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "beverage_type_translation",
                keyColumn: "id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "beverage_type_translation",
                keyColumn: "id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "beverage_type_translation",
                keyColumn: "id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "beverage_type_translation",
                keyColumn: "id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "beverage_type_translation",
                keyColumn: "id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "beverage_type_translation",
                keyColumn: "id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "beverage_type",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "beverage_type",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "beverage_type",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "beverage_type",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "beverage_type",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.AlterColumn<long>(
                name: "beverage_type_id",
                table: "beverage_type_translation",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
