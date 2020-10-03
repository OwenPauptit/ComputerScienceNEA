using Microsoft.EntityFrameworkCore.Migrations;

namespace NEA.Migrations
{
    public partial class isCorrectEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Correct",
                table: "StudentQuestion");

            migrationBuilder.AddColumn<int>(
                name: "isCorrect",
                table: "StudentQuestion",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isCorrect",
                table: "StudentQuestion");

            migrationBuilder.AddColumn<bool>(
                name: "Correct",
                table: "StudentQuestion",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
