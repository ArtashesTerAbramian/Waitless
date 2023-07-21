using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Waitless.DAL.Migrations
{
    public partial class mail_template : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "activation_token",
                table: "users",
                type: "character varying(120)",
                maxLength: 120,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "mail_template",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    html_body = table.Column<string>(type: "text", nullable: false),
                    subject = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mail_template", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "mail_template",
                columns: new[] { "id", "created_date", "html_body", "is_deleted", "modify_date", "subject" },
                values: new object[,]
                {
                    { 1L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "\r\n                        <!DOCTYPE html>\r\n                        <html>\r\n                        <head>\r\n                            <title>Waitless - Email Verification</title>\r\n                        </head>\r\n                        <body style=\"font-family: Arial, sans-serif; line-height: 1.6;\">\r\n                            <h2>Dear {FirstName},</h2>\r\n                            <p>\r\n                                Thank you for joining Waitless! To activate your account and access our services,\r\n                                please verify your email address by clicking the link below:\r\n                            </p>\r\n                            <p style=\"background-color: #f2f2f2; padding: 10px;\">\r\n                                <a href=\"{verificationLink}\" target=\"_blank\" style=\"color: #007BFF; text-decoration: none;\">\r\n                                    {verificationLink}\r\n                                </a>\r\n                            </p>\r\n                            <p>\r\n                                If you did not sign up for Waitless, please ignore this email.\r\n                            </p>\r\n                            <p>Best regards,</p>\r\n                            <p>Waitless team</p>\r\n                        </body>\r\n                        </html>\r\n                        ", false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Waitless Mail Verification" },
                    { 2L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "\r\n                        <!DOCTYPE html>\r\n                        <html>\r\n                        <head>\r\n                            <title>Waitless - Password Reset</title>\r\n                        </head>\r\n                        <body style=\"font-family: Arial, sans-serif; line-height: 1.6;\">\r\n                            <h2>Dear {FirstName},</h2>\r\n                            <p>\r\n                                We received a request to reset your password for your Waitless account. \r\n                                If you didn't initiate this request, you can ignore this email.\r\n                            </p>\r\n                            <p>\r\n                                To reset your password, click on the link below:\r\n                            </p>\r\n                            <p style=\"background-color: #f2f2f2; padding: 10px;\">\r\n                                <a href=\"{resetLink}\" target=\"_blank\" style=\"color: #007BFF; text-decoration: none;\">\r\n                                    Reset Password\r\n                                </a>\r\n                            </p>\r\n                            <p>\r\n                                If the above link doesn't work, you can copy and paste the following URL \r\n                                into your web browser's address bar:\r\n                            </p>\r\n                            <p>\r\n                                This password reset link will expire in 24 hour.\r\n                            </p>\r\n                            <p>\r\n                                If you didn't request a password reset, no action is required on your part.\r\n                            </p>\r\n                            <p>Best regards,</p>\r\n                            <p>Waitless team</p>\r\n                        </body>\r\n                        </html>\r\n                        ", false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Waitless Reset Password" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_mail_template_created_date",
                table: "mail_template",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_mail_template_is_deleted",
                table: "mail_template",
                column: "is_deleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mail_template");

            migrationBuilder.DropColumn(
                name: "activation_token",
                table: "users");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "users");
        }
    }
}
