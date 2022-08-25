using Microsoft.EntityFrameworkCore.Migrations;

namespace Pull_Bear.Data.Migrations
{
    public partial class AddedGenderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "BodyFits",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_GenderId",
                table: "Products",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_GenderId",
                table: "Categories",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_BodyFits_GenderId",
                table: "BodyFits",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_BodyFits_Genders_GenderId",
                table: "BodyFits",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Genders_GenderId",
                table: "Categories",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Genders_GenderId",
                table: "Products",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BodyFits_Genders_GenderId",
                table: "BodyFits");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Genders_GenderId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Genders_GenderId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropIndex(
                name: "IX_Products_GenderId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Categories_GenderId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_BodyFits_GenderId",
                table: "BodyFits");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "BodyFits");
        }
    }
}
