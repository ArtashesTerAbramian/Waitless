using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Waitless.DAL.Migrations
{
    public partial class merchant_config : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "user_name",
                table: "merchant",
                type: "character varying(512)",
                maxLength: 512,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "merchant",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "password_hash",
                table: "merchant",
                type: "character varying(512)",
                maxLength: 512,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "merchant",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "merchant",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "ix_merchant_email",
                table: "merchant",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_merchant_user_name",
                table: "merchant",
                column: "user_name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_merchant_email",
                table: "merchant");

            migrationBuilder.DropIndex(
                name: "ix_merchant_user_name",
                table: "merchant");

            migrationBuilder.AlterColumn<string>(
                name: "user_name",
                table: "merchant",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(512)",
                oldMaxLength: 512);

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "merchant",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "password_hash",
                table: "merchant",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(512)",
                oldMaxLength: 512);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "merchant",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "merchant",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);
        }
    }
}
