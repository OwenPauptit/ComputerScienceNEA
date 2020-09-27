using Microsoft.EntityFrameworkCore.Migrations;

namespace NEA.Migrations
{
    public partial class StuQuestAssignFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentAssignmentSimulationID",
                table: "StudentQuestion",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentAssignmentUserID",
                table: "StudentQuestion",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuestion_StudentAssignmentUserID_StudentAssignmentSimulationID",
                table: "StudentQuestion",
                columns: new[] { "StudentAssignmentUserID", "StudentAssignmentSimulationID" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuestion_UserID_SimulationID",
                table: "StudentQuestion",
                columns: new[] { "UserID", "SimulationID" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentQuestion_StudentAssignment_StudentAssignmentUserID_StudentAssignmentSimulationID",
                table: "StudentQuestion",
                columns: new[] { "StudentAssignmentUserID", "StudentAssignmentSimulationID" },
                principalTable: "StudentAssignment",
                principalColumns: new[] { "UserID", "SimulationID" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentQuestion_StudentAssignment_UserID_SimulationID",
                table: "StudentQuestion",
                columns: new[] { "UserID", "SimulationID" },
                principalTable: "StudentAssignment",
                principalColumns: new[] { "UserID", "SimulationID" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuestion_StudentAssignment_StudentAssignmentUserID_StudentAssignmentSimulationID",
                table: "StudentQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuestion_StudentAssignment_UserID_SimulationID",
                table: "StudentQuestion");

            migrationBuilder.DropIndex(
                name: "IX_StudentQuestion_StudentAssignmentUserID_StudentAssignmentSimulationID",
                table: "StudentQuestion");

            migrationBuilder.DropIndex(
                name: "IX_StudentQuestion_UserID_SimulationID",
                table: "StudentQuestion");

            migrationBuilder.DropColumn(
                name: "StudentAssignmentSimulationID",
                table: "StudentQuestion");

            migrationBuilder.DropColumn(
                name: "StudentAssignmentUserID",
                table: "StudentQuestion");
        }
    }
}
