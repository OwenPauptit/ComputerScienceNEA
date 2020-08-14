using Microsoft.EntityFrameworkCore.Migrations;

namespace NEA.Migrations
{
    public partial class RemoveUnnecessaryProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassID",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Enrollment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClassID",
                table: "Enrollment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "Enrollment",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
