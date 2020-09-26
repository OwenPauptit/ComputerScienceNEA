using Microsoft.EntityFrameworkCore.Migrations;

namespace NEA.Migrations
{
    public partial class StudentQModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AnswerFormat",
                table: "QuestionType",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "StudentQuestion",
                columns: table => new
                {
                    SimulationID = table.Column<int>(nullable: false),
                    QIndex = table.Column<int>(nullable: false),
                    UserID = table.Column<string>(nullable: false),
                    Answer = table.Column<string>(nullable: true),
                    Correct = table.Column<bool>(nullable: false),
                    QuestionQIndex = table.Column<int>(nullable: true),
                    QuestionSimulationID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentQuestion", x => new { x.SimulationID, x.QIndex, x.UserID });
                    table.ForeignKey(
                        name: "FK_StudentQuestion_Simulation_SimulationID",
                        column: x => x.SimulationID,
                        principalTable: "Simulation",
                        principalColumn: "SimulationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentQuestion_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentQuestion_Question_QuestionSimulationID_QuestionQIndex",
                        columns: x => new { x.QuestionSimulationID, x.QuestionQIndex },
                        principalTable: "Question",
                        principalColumns: new[] { "SimulationID", "QIndex" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentQuestion_Question_SimulationID_QIndex",
                        columns: x => new { x.SimulationID, x.QIndex },
                        principalTable: "Question",
                        principalColumns: new[] { "SimulationID", "QIndex" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuestion_UserID",
                table: "StudentQuestion",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuestion_QuestionSimulationID_QuestionQIndex",
                table: "StudentQuestion",
                columns: new[] { "QuestionSimulationID", "QuestionQIndex" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentQuestion");

            migrationBuilder.AlterColumn<string>(
                name: "AnswerFormat",
                table: "QuestionType",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
