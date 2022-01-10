using Microsoft.EntityFrameworkCore.Migrations;

namespace YogaStudio.Migrations
{
    public partial class user_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subscriptions_users_user_id",
                table: "subscriptions");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.AddForeignKey(
                name: "FK_subscriptions_AspNetUsers_user_id",
                table: "subscriptions",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subscriptions_AspNetUsers_user_id",
                table: "subscriptions");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_subscriptions_users_user_id",
                table: "subscriptions",
                column: "user_id",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
