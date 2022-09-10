using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pull_Bear.Data.Migrations
{
    public partial class AddedCardAndAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsUpdated = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Address1 = table.Column<string>(maxLength: 40, nullable: false),
                    Address2 = table.Column<string>(maxLength: 40, nullable: false),
                    Country = table.Column<string>(maxLength: 60, nullable: false),
                    City = table.Column<string>(maxLength: 22, nullable: false),
                    ZipCode = table.Column<string>(maxLength: 12, nullable: false),
                    IsMain = table.Column<bool>(nullable: false),
                    AppUserId1 = table.Column<string>(nullable: true),
                    AppUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_AspNetUsers_AppUserId1",
                        column: x => x.AppUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsUpdated = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    CardNo = table.Column<string>(maxLength: 16, nullable: false),
                    CVV = table.Column<int>(maxLength: 4, nullable: false),
                    CardHolder = table.Column<string>(maxLength: 50, nullable: false),
                    ExpireDate = table.Column<string>(maxLength: 7, nullable: false),
                    IsMain = table.Column<bool>(nullable: false),
                    AppUserId1 = table.Column<string>(nullable: true),
                    AppUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_AspNetUsers_AppUserId1",
                        column: x => x.AppUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AppUserId1",
                table: "Addresses",
                column: "AppUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_AppUserId1",
                table: "Cards",
                column: "AppUserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Cards");
        }
    }
}
