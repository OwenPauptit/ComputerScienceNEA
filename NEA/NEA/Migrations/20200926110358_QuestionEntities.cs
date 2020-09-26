using Microsoft.EntityFrameworkCore.Migrations;

namespace NEA.Migrations
{
    public partial class QuestionEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    AnswerFormat = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    SimulationID = table.Column<int>(nullable: false),
                    QIndex = table.Column<int>(nullable: false),
                    QuestionTypeID = table.Column<int>(nullable: false),
                    QuestionString = table.Column<string>(nullable: false),
                    AnswerString = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => new { x.SimulationID, x.QIndex });
                    table.ForeignKey(
                        name: "FK_Question_QuestionType_QuestionTypeID",
                        column: x => x.QuestionTypeID,
                        principalTable: "QuestionType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Question_Simulation_SimulationID",
                        column: x => x.SimulationID,
                        principalTable: "Simulation",
                        principalColumn: "SimulationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuestionTypeID",
                table: "Question",
                column: "QuestionTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "QuestionType");
        }
    }
}
