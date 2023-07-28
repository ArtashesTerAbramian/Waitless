using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Waitless.DAL.Migrations
{
    public partial class userresetmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "vendor_id",
                table: "product",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "vendor_id",
                table: "orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "vendor_id",
                table: "address",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "user_password_reset",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    token = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    expired = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_password_reset", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_password_reset_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "product_type_translation",
                keyColumn: "id",
                keyValue: 15L,
                column: "name",
                value: "Հյութ");

            migrationBuilder.CreateIndex(
                name: "ix_user_password_reset_created_date",
                table: "user_password_reset",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_user_password_reset_is_deleted",
                table: "user_password_reset",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_user_password_reset_user_id",
                table: "user_password_reset",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_password_reset");

            migrationBuilder.DropColumn(
                name: "vendor_id",
                table: "product");

            migrationBuilder.DropColumn(
                name: "vendor_id",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "vendor_id",
                table: "address");

            migrationBuilder.UpdateData(
                table: "product_type_translation",
                keyColumn: "id",
                keyValue: 15L,
                column: "name",
                value: "Ջուս");
        }
    }
}
