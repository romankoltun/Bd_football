using Microsoft.EntityFrameworkCore.Migrations;

namespace Bd_web.Migrations
{
    public partial class tt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Shops_Shop_TId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_Shop_TId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Max_Sector",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Shop_TId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "max_row",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "max_sition",
                table: "Matches");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Max_Sector",
                table: "Matches",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Shop_TId",
                table: "Matches",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "max_row",
                table: "Matches",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "max_sition",
                table: "Matches",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Shop_TId",
                table: "Matches",
                column: "Shop_TId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Shops_Shop_TId",
                table: "Matches",
                column: "Shop_TId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
