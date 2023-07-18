using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Waitless.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "error",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_error", x => x.id);
                });

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

            migrationBuilder.CreateTable(
                name: "product_size",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    size_enum = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_size", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product_type",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "provinces",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_provinces", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_name = table.Column<string>(type: "text", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product_size_translation",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_size_id = table.Column<long>(type: "bigint", nullable: false),
                    size = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    language_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_size_translation", x => x.id);
                    table.ForeignKey(
                        name: "fk_product_size_translation_product_size_product_size_id",
                        column: x => x.product_size_id,
                        principalTable: "product_size",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_type_id = table.Column<long>(type: "bigint", nullable: true),
                    product_size_id = table.Column<long>(type: "bigint", nullable: true),
                    price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product", x => x.id);
                    table.ForeignKey(
                        name: "fk_product_product_size_product_size_id",
                        column: x => x.product_size_id,
                        principalTable: "product_size",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_product_product_types_product_type_id",
                        column: x => x.product_type_id,
                        principalTable: "product_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product_type_translation",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_type_id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    language_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_type_translation", x => x.id);
                    table.ForeignKey(
                        name: "fk_product_type_translation_product_type_product_type_id",
                        column: x => x.product_type_id,
                        principalTable: "product_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    province_id = table.Column<long>(type: "bigint", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_city", x => x.id);
                    table.ForeignKey(
                        name: "fk_city_provinces_province_id",
                        column: x => x.province_id,
                        principalTable: "provinces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "province_translation",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    province_id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    language_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_province_translation", x => x.id);
                    table.ForeignKey(
                        name: "fk_province_translation_provinces_province_id",
                        column: x => x.province_id,
                        principalTable: "provinces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cart",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    total_price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cart", x => x.id);
                    table.ForeignKey(
                        name: "fk_cart_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_session",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    token = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    is_expired = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_session", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_session_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product_photo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    file_url = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_photo", x => x.id);
                    table.ForeignKey(
                        name: "fk_product_photo_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product_translation",
                columns: table => new
                {
                    language_id = table.Column<int>(type: "integer", nullable: false),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    description = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    id = table.Column<long>(type: "bigint", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_translation", x => new { x.language_id, x.product_id });
                    table.ForeignKey(
                        name: "fk_product_translation_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    city_id = table.Column<long>(type: "bigint", nullable: false),
                    postal_code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_address", x => x.id);
                    table.ForeignKey(
                        name: "fk_address_cities_city_id",
                        column: x => x.city_id,
                        principalTable: "city",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "city_translation",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    city_id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    language_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_city_translation", x => x.id);
                    table.ForeignKey(
                        name: "fk_city_translation_city_city_id",
                        column: x => x.city_id,
                        principalTable: "city",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "address_translation",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    address_id = table.Column<long>(type: "bigint", nullable: false),
                    street = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    language_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_address_translation", x => x.id);
                    table.ForeignKey(
                        name: "fk_address_translation_address_address_id",
                        column: x => x.address_id,
                        principalTable: "address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "error",
                columns: new[] { "id", "created_date", "is_deleted", "modify_date", "name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Oops! Something wen't wrong" },
                    { 2L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Not Authorized." },
                    { 3L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Error while authorizing." },
                    { 4L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "User Not Found." },
                    { 5L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "User with provided username already exists." },
                    { 6L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Entered data is not correct." },
                    { 7L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Item Not Found." },
                    { 8L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "The entered item already exists." },
                    { 9L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Error. This component cannot be deleted." },
                    { 10L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "The specified email address is already taken." },
                    { 11L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Total error." }
                });

            migrationBuilder.InsertData(
                table: "product_size",
                columns: new[] { "id", "created_date", "is_deleted", "modify_date", "size_enum" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 2L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2 },
                    { 3L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3 }
                });

            migrationBuilder.InsertData(
                table: "product_type",
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
                table: "provinces",
                columns: new[] { "id", "created_date", "is_deleted", "modify_date" },
                values: new object[,]
                {
                    { 1L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 3L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 4L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 5L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 6L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 7L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 8L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 9L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 10L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 11L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "created_date", "email", "is_deleted", "modify_date", "password_hash", "phone", "user_name" },
                values: new object[] { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@mail.com", false, null, "jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg=", "32423", "admin" });

            migrationBuilder.InsertData(
                table: "city",
                columns: new[] { "id", "created_date", "is_deleted", "modify_date", "province_id" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 2L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 3L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 4L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 5L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 6L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 7L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 8L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 9L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 10L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 11L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 12L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 13L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 14L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 15L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 16L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 17L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 18L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 19L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 20L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 21L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 22L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 23L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 24L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 25L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 26L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 27L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 28L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 29L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 30L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 31L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 32L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 33L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 34L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 35L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 36L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 37L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 38L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 39L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 40L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 41L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 42L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 43L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 44L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 45L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 46L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 47L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 48L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 49L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 50L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 51L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 52L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 53L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 54L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 55L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 56L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 57L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 58L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 59L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 60L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 61L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 62L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 63L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 64L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 65L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 66L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 67L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 68L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L },
                    { 69L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4L }
                });

            migrationBuilder.InsertData(
                table: "product_size_translation",
                columns: new[] { "id", "created_date", "is_deleted", "language_id", "modify_date", "product_size_id", "size" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1L, "Small" },
                    { 2L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1L, "Маленький" },
                    { 3L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1L, "Փոքր" },
                    { 4L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2L, "Medium" },
                    { 5L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2L, "Средний" },
                    { 6L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2L, "Միջին" },
                    { 7L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3L, "Large" },
                    { 8L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3L, "Большой" },
                    { 9L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3L, "Մեծ" }
                });

            migrationBuilder.InsertData(
                table: "product_type_translation",
                columns: new[] { "id", "created_date", "is_deleted", "language_id", "modify_date", "name", "product_type_id" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Coffee", 1L },
                    { 2L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Кофе", 1L },
                    { 3L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Սուրճ", 1L },
                    { 4L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Tea", 2L },
                    { 5L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Чай", 2L },
                    { 6L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Թեյ", 2L },
                    { 7L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Smoothie", 3L },
                    { 8L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Смузи", 3L },
                    { 9L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Սմուզի", 3L },
                    { 10L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Lemonade", 4L },
                    { 11L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Лимонад", 4L },
                    { 12L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Լիմոնադ", 4L },
                    { 13L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Juice", 5L },
                    { 14L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Сок", 5L },
                    { 15L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ջուս", 5L }
                });

            migrationBuilder.InsertData(
                table: "province_translation",
                columns: new[] { "id", "created_date", "is_deleted", "language_id", "modify_date", "name", "province_id" },
                values: new object[,]
                {
                    { 1L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Aragatsotn region", 1L },
                    { 2L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Арагацотнская область", 1L },
                    { 3L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Արագածոտնի մարզ", 1L },
                    { 4L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ararat region", 2L },
                    { 5L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Араратская область", 2L },
                    { 6L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Արարատյան մարզ", 2L },
                    { 7L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Armavir region", 3L },
                    { 8L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Армавирская область", 3L },
                    { 9L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Արմավիրի մարզ", 3L },
                    { 10L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Yerevan", 4L },
                    { 11L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ереван", 4L },
                    { 12L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Երեվան", 4L },
                    { 13L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Vayots Dzor region", 5L },
                    { 14L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Вайоцдзорская бласть", 5L },
                    { 15L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Վայոց Ձորի մարզ", 5L },
                    { 16L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gegharkunik region", 6L },
                    { 17L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Гехаркуникская область", 6L },
                    { 18L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Գեղարքունիքի մարզ", 6L },
                    { 19L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Kotayk region", 7L },
                    { 20L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Котайкская область", 7L },
                    { 21L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Կոտայքի մարզ", 7L },
                    { 22L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Lori region", 8L },
                    { 23L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Лорийская область", 8L },
                    { 24L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Լոռու մարզ", 8L },
                    { 25L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Shirak region", 9L },
                    { 26L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ширакская область", 9L },
                    { 27L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Շիրակի մարզ", 9L },
                    { 28L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Tavush region", 10L },
                    { 29L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Тавушская область", 10L },
                    { 30L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Տավուշի մարզ", 10L },
                    { 31L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Syunik region", 11L },
                    { 32L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Сюникская область", 11L },
                    { 33L, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Սյունիքի մարզ", 11L }
                });

            migrationBuilder.InsertData(
                table: "city_translation",
                columns: new[] { "id", "city_id", "created_date", "is_deleted", "language_id", "modify_date", "name" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Yerevan" },
                    { 2L, 1L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ереван" },
                    { 3L, 1L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Երևան" },
                    { 4L, 2L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Aparan" },
                    { 5L, 2L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Апаран" },
                    { 6L, 2L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ապարան" },
                    { 7L, 3L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Artashat" },
                    { 8L, 3L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Арташат" },
                    { 9L, 3L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Արթաշատ" },
                    { 10L, 4L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Vanaadzor" },
                    { 11L, 4L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ванадзор" },
                    { 12L, 4L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Վանաձոր" },
                    { 13L, 5L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gyumri" },
                    { 14L, 5L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Гюмри" },
                    { 15L, 5L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Գյումրի" },
                    { 16L, 6L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Goris" },
                    { 17L, 6L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Горис" },
                    { 18L, 6L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Գորիս" },
                    { 19L, 7L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Hrazdan" },
                    { 20L, 7L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Граздан" },
                    { 21L, 7L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Հրազդան" },
                    { 22L, 8L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Kapan" },
                    { 23L, 8L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Капан" },
                    { 24L, 8L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Քանաքեռավան" },
                    { 25L, 9L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Masis" },
                    { 26L, 9L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Масис" },
                    { 27L, 9L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Մարալիկ" },
                    { 28L, 10L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Sebastia" },
                    { 29L, 10L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Себастия" },
                    { 30L, 10L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Սեբաստիա" },
                    { 31L, 11L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Stepanavan" },
                    { 32L, 11L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Степанаван" },
                    { 33L, 11L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ստեփանավան" },
                    { 34L, 12L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Abovyan" },
                    { 35L, 12L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Абовян" },
                    { 36L, 12L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Աբովյան" },
                    { 37L, 13L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Agharak" },
                    { 38L, 13L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Агарак" },
                    { 39L, 13L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ագարակ" },
                    { 40L, 14L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Alaverdi" },
                    { 41L, 14L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Алаверди" },
                    { 42L, 14L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ալավերդի" },
                    { 43L, 15L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ashtarak" },
                    { 44L, 15L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Аштарак" },
                    { 45L, 15L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Աշտարակ" },
                    { 46L, 16L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Aparan" },
                    { 47L, 16L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Апаран" },
                    { 48L, 16L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ապարան" },
                    { 49L, 17L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ararat" },
                    { 50L, 17L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Арарат" },
                    { 51L, 17L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Արարատ" },
                    { 52L, 18L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Arats" },
                    { 53L, 18L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Аратс" },
                    { 54L, 18L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Արարած" },
                    { 55L, 19L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Armavir" },
                    { 56L, 19L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Армавир" },
                    { 57L, 19L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Արմավիր" },
                    { 58L, 20L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Arevmat" },
                    { 59L, 20L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Аревмат" },
                    { 60L, 20L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Արևամուտ" },
                    { 61L, 21L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gavar" },
                    { 62L, 21L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Гавар" },
                    { 63L, 21L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Գավառ" },
                    { 64L, 22L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gyumri" },
                    { 65L, 22L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Гюмри" },
                    { 66L, 22L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Գյումրի" },
                    { 67L, 23L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Dilijan" },
                    { 68L, 23L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Дилижан" },
                    { 69L, 23L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Դիլիջան" },
                    { 70L, 24L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Yeghegnadzor" },
                    { 71L, 24L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Егегнадзор" },
                    { 72L, 24L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Եղեգնաձոր" },
                    { 73L, 25L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Yegvard" },
                    { 74L, 25L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Егвард" },
                    { 75L, 25L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Եղվարդ" },
                    { 76L, 26L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Yeghegnik" },
                    { 77L, 26L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Егегник" },
                    { 78L, 26L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Եգեղեցիկ" },
                    { 79L, 27L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Yeveran" },
                    { 80L, 27L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Еверан" },
                    { 81L, 27L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Եվերեան" },
                    { 82L, 28L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ejmiatsin" },
                    { 83L, 28L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Эчмиадзин" },
                    { 84L, 28L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Էջմիածին" },
                    { 85L, 29L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Talin" },
                    { 86L, 29L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Талин" },
                    { 87L, 29L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Թալին" },
                    { 88L, 30L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Tumanyan" },
                    { 89L, 30L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Туманян" },
                    { 90L, 30L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Թումանյան" },
                    { 91L, 31L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Tijvat" },
                    { 92L, 31L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Тийват" },
                    { 93L, 31L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Թիջուատ" },
                    { 94L, 32L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Zhambarak" },
                    { 95L, 32L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Жамбарак" },
                    { 96L, 32L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ժամբարակ" },
                    { 97L, 33L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ijevan" },
                    { 98L, 33L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Иджеван" },
                    { 99L, 33L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Իջևան" },
                    { 100L, 34L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Lernamut" },
                    { 101L, 34L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Лернамут" },
                    { 102L, 34L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Լեռնամուտ" },
                    { 103L, 35L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Lori" },
                    { 104L, 35L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Лори" },
                    { 105L, 35L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Լոռի" },
                    { 106L, 36L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Khanakerd" },
                    { 107L, 36L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ханакерт" },
                    { 108L, 36L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Խանաքեռավան" },
                    { 109L, 37L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Tsaghkadzor" },
                    { 110L, 37L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Цахкадзор" },
                    { 111L, 37L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ծաղկաձոր" },
                    { 112L, 38L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Kapan" },
                    { 113L, 38L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Капан" },
                    { 114L, 38L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Կապան" },
                    { 115L, 39L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Sisian" },
                    { 116L, 39L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Сисиан" },
                    { 117L, 39L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Կասախաղ" },
                    { 118L, 40L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Kanachar" },
                    { 119L, 40L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Каначар" },
                    { 120L, 40L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Կանանցառ" },
                    { 121L, 41L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Kapanavan" },
                    { 122L, 41L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Капанаван" },
                    { 123L, 41L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Կապանավան" },
                    { 124L, 42L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Kotayk" },
                    { 125L, 42L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Котайк" },
                    { 126L, 42L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Կոտայք" },
                    { 127L, 43L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Hrazdan" },
                    { 128L, 43L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Граздан" },
                    { 129L, 43L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Հրազդան" },
                    { 130L, 44L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Hrayravan" },
                    { 131L, 44L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Грайраван" },
                    { 132L, 44L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Հարավային Մարտունի" },
                    { 133L, 45L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Jamburak" },
                    { 134L, 45L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Джамбурак" },
                    { 135L, 45L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ճամբարակ" },
                    { 136L, 46L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Masis" },
                    { 137L, 46L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Масис" },
                    { 138L, 46L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Մասիս" },
                    { 139L, 47L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Maralik" },
                    { 140L, 47L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Маралик" },
                    { 141L, 47L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Մարալիկ" },
                    { 142L, 48L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Martakert" },
                    { 143L, 48L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Мартакерт" },
                    { 144L, 48L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Մարտակերտ" },
                    { 145L, 49L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Martuni" },
                    { 146L, 49L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Мартуни" },
                    { 147L, 49L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Մարտունի" },
                    { 148L, 50L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Meghri" },
                    { 149L, 50L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Мегри" },
                    { 150L, 50L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Մեծամոր" },
                    { 151L, 51L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "United Armenia" },
                    { 152L, 51L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Объединенная Армения" },
                    { 153L, 51L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Միացյալ Հայաստան" },
                    { 154L, 52L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Moscow" },
                    { 155L, 52L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Москва" },
                    { 156L, 52L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Մոսկվա" },
                    { 157L, 53L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "November" },
                    { 158L, 53L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ноябрь" },
                    { 159L, 53L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Նոյեմբերյան" },
                    { 160L, 54L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "New Jdeidah" },
                    { 161L, 54L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Новый Джейда" },
                    { 162L, 54L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Նոր Հաճըն" },
                    { 163L, 55L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Shahumyan" },
                    { 164L, 55L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Шахумян" },
                    { 165L, 55L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Շահումյան" },
                    { 166L, 56L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Shavarshen" },
                    { 167L, 56L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Шаваршен" },
                    { 168L, 56L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Շավարշեն" },
                    { 169L, 57L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Shirak" },
                    { 170L, 57L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ширак" },
                    { 171L, 57L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Շիրակ" },
                    { 172L, 58L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Shushi" },
                    { 173L, 58L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Шуши" },
                    { 174L, 58L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Շուշի" },
                    { 175L, 59L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Sutis" },
                    { 176L, 59L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Сутис" },
                    { 177L, 59L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Շուտիս" },
                    { 178L, 60L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Sisian" },
                    { 179L, 60L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Сисиан" },
                    { 180L, 60L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Սիսիան" },
                    { 181L, 61L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Syunik" },
                    { 182L, 61L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Сюник" },
                    { 183L, 61L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Սյունիք" },
                    { 184L, 62L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Stepanavan" },
                    { 185L, 62L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Степанаван" },
                    { 186L, 62L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ստեփանավան" },
                    { 187L, 63L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Stepanakert" },
                    { 188L, 63L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Степанакерт" },
                    { 189L, 63L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ստեփանակերտ" },
                    { 190L, 64L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Stepanavan" },
                    { 191L, 64L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Степанаван" },
                    { 192L, 64L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ստեփանավունի" },
                    { 193L, 65L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Sevan" },
                    { 194L, 65L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Севан" },
                    { 195L, 65L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Սևան" },
                    { 196L, 66L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Tashir" },
                    { 197L, 66L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ташир" },
                    { 198L, 66L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Տաշիր" },
                    { 199L, 67L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Tavush" },
                    { 200L, 67L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Тавуш" },
                    { 201L, 67L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Տավուշ" },
                    { 202L, 68L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Kasakh" },
                    { 203L, 68L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Касах" },
                    { 204L, 68L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Քասախ" },
                    { 205L, 69L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Kaghakanysh" },
                    { 206L, 69L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Кагаканиш" },
                    { 207L, 69L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Քաղաքանիշ" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_address_city_id",
                table: "address",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "ix_address_created_date",
                table: "address",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_address_is_deleted",
                table: "address",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_address_translation_address_id",
                table: "address_translation",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "ix_address_translation_created_date",
                table: "address_translation",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_address_translation_is_deleted",
                table: "address_translation",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_cart_created_date",
                table: "cart",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_cart_is_deleted",
                table: "cart",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_cart_user_id",
                table: "cart",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_city_created_date",
                table: "city",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_city_is_deleted",
                table: "city",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_city_province_id",
                table: "city",
                column: "province_id");

            migrationBuilder.CreateIndex(
                name: "ix_city_translation_city_id",
                table: "city_translation",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "ix_city_translation_created_date",
                table: "city_translation",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_city_translation_is_deleted",
                table: "city_translation",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_error_created_date",
                table: "error",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_error_is_deleted",
                table: "error",
                column: "is_deleted");

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

            migrationBuilder.CreateIndex(
                name: "ix_product_created_date",
                table: "product",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_product_is_deleted",
                table: "product",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_product_product_size_id",
                table: "product",
                column: "product_size_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_product_type_id",
                table: "product",
                column: "product_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_photo_created_date",
                table: "product_photo",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_product_photo_is_deleted",
                table: "product_photo",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_product_photo_product_id",
                table: "product_photo",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_size_created_date",
                table: "product_size",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_product_size_is_deleted",
                table: "product_size",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_product_size_translation_created_date",
                table: "product_size_translation",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_product_size_translation_is_deleted",
                table: "product_size_translation",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_product_size_translation_product_size_id",
                table: "product_size_translation",
                column: "product_size_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_translation_created_date",
                table: "product_translation",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_product_translation_is_deleted",
                table: "product_translation",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_product_translation_product_id",
                table: "product_translation",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_type_created_date",
                table: "product_type",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_product_type_is_deleted",
                table: "product_type",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_product_type_translation_created_date",
                table: "product_type_translation",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_product_type_translation_is_deleted",
                table: "product_type_translation",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_product_type_translation_product_type_id",
                table: "product_type_translation",
                column: "product_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_province_translation_created_date",
                table: "province_translation",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_province_translation_is_deleted",
                table: "province_translation",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_province_translation_province_id",
                table: "province_translation",
                column: "province_id");

            migrationBuilder.CreateIndex(
                name: "ix_provinces_created_date",
                table: "provinces",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_provinces_is_deleted",
                table: "provinces",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_user_session_created_date",
                table: "user_session",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_user_session_is_deleted",
                table: "user_session",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_user_session_user_id",
                table: "user_session",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_created_date",
                table: "users",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_is_deleted",
                table: "users",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_users_user_name",
                table: "users",
                column: "user_name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "address_translation");

            migrationBuilder.DropTable(
                name: "cart");

            migrationBuilder.DropTable(
                name: "city_translation");

            migrationBuilder.DropTable(
                name: "error");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "product_photo");

            migrationBuilder.DropTable(
                name: "product_size_translation");

            migrationBuilder.DropTable(
                name: "product_translation");

            migrationBuilder.DropTable(
                name: "product_type_translation");

            migrationBuilder.DropTable(
                name: "province_translation");

            migrationBuilder.DropTable(
                name: "user_session");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "product_size");

            migrationBuilder.DropTable(
                name: "product_type");

            migrationBuilder.DropTable(
                name: "provinces");
        }
    }
}
