using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace YogaStudio.Migrations
{
    public partial class sub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subscriptions_AspNetUsers_user_id",
                table: "subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_subscriptions_sub_durations_DurationId",
                table: "subscriptions");

            migrationBuilder.DropTable(
                name: "sub_durations");

            migrationBuilder.DropIndex(
                name: "IX_subscriptions_DurationId",
                table: "subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_subscriptions_user_id",
                table: "subscriptions");

            migrationBuilder.DropColumn(
                name: "DurationId",
                table: "subscriptions");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "subscriptions");

            migrationBuilder.AddColumn<bool>(
                name: "IsValid",
                table: "subscriptions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubInit",
                table: "subscriptions",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SubscriptionExpiringDate",
                table: "subscriptions",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "SubscriptionId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: false),
                    LastName = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: false),
                    Address = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    City = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    State = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    PostalCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Country = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Phone = table.Column<string>(type: "character varying(24)", maxLength: 24, nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentTransactionId = table.Column<string>(type: "text", nullable: true),
                    HasBeenShipped = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: true),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UnitPrice = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SubscriptionId",
                table: "AspNetUsers",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_subscriptions_SubscriptionId",
                table: "AspNetUsers",
                column: "SubscriptionId",
                principalTable: "subscriptions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_subscriptions_SubscriptionId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SubscriptionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsValid",
                table: "subscriptions");

            migrationBuilder.DropColumn(
                name: "SubInit",
                table: "subscriptions");

            migrationBuilder.DropColumn(
                name: "SubscriptionExpiringDate",
                table: "subscriptions");

            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "DurationId",
                table: "subscriptions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "user_id",
                table: "subscriptions",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "sub_durations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sub_durations", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_subscriptions_DurationId",
                table: "subscriptions",
                column: "DurationId");

            migrationBuilder.CreateIndex(
                name: "IX_subscriptions_user_id",
                table: "subscriptions",
                column: "user_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_subscriptions_AspNetUsers_user_id",
                table: "subscriptions",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_subscriptions_sub_durations_DurationId",
                table: "subscriptions",
                column: "DurationId",
                principalTable: "sub_durations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
