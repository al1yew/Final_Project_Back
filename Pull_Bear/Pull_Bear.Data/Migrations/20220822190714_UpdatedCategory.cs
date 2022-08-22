using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pull_Bear.Data.Migrations
{
    public partial class UpdatedCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeteledAt",
                table: "Categories");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Categories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Categories");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeteledAt",
                table: "Categories",
                type: "datetime2",
                nullable: true);
        }
    }
}
