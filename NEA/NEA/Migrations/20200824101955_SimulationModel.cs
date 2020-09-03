using Microsoft.EntityFrameworkCore.Migrations;

namespace NEA.Migrations
{
    public partial class SimulationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Simulation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreviewImgSrc",
                table: "Simulation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Simulation");

            migrationBuilder.DropColumn(
                name: "PreviewImgSrc",
                table: "Simulation");
        }
    }
}
