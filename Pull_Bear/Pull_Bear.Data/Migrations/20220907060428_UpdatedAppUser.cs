using Microsoft.EntityFrameworkCore.Migrations;

namespace Pull_Bear.Data.Migrations
{
    public partial class UpdatedAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "ProductReviews",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_AppUserId",
                table: "ProductReviews",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReviews_AspNetUsers_AppUserId",
                table: "ProductReviews",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviews_AspNetUsers_AppUserId",
                table: "ProductReviews");

            migrationBuilder.DropIndex(
                name: "IX_ProductReviews_AppUserId",
                table: "ProductReviews");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "ProductReviews");
        }
    }
}
