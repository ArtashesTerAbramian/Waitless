using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Waitless.DAL.Migrations
{
    public partial class order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "order_id",
                table: "coffee",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    address_id = table.Column<long>(type: "bigint", nullable: false),
                    instruction = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    timing_type = table.Column<int>(type: "integer", nullable: true),
                    be_ready_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_ready = table.Column<bool>(type: "boolean", nullable: false),
                    total_price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_coffee_order_id",
                table: "coffee",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "ix_orders_address_id_user_id",
                table: "orders",
                columns: new[] { "address_id", "user_id" });

            migrationBuilder.CreateIndex(
                name: "ix_orders_created_date",
                table: "orders",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_orders_is_deleted",
                table: "orders",
                column: "is_deleted");

            migrationBuilder.AddForeignKey(
                name: "fk_coffee_orders_order_id",
                table: "coffee",
                column: "order_id",
                principalTable: "orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_coffee_orders_order_id",
                table: "coffee");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropIndex(
                name: "ix_coffee_order_id",
                table: "coffee");

            migrationBuilder.DropColumn(
                name: "order_id",
                table: "coffee");
        }
    }
}
