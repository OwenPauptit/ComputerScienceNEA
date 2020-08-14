using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NEA.Migrations
{
    public partial class InitialModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClassroomClassID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Classroom",
                columns: table => new
                {
                    ClassID = table.Column<string>(maxLength: 10, nullable: false),
                    TeacherID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classroom", x => x.ClassID);
                    table.ForeignKey(
                        name: "FK_Classroom_AspNetUsers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Simulation",
                columns: table => new
                {
                    SimulationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simulation", x => x.SimulationID);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    StudentID = table.Column<string>(nullable: false),
                    ClassID = table.Column<string>(nullable: false),
                    ClassroomClassID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => new { x.StudentID, x.ClassID });
                    table.ForeignKey(
                        name: "FK_Enrollment_Classroom_ClassroomClassID",
                        column: x => x.ClassroomClassID,
                        principalTable: "Classroom",
                        principalColumn: "ClassID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enrollment_AspNetUsers_StudentID",
                        column: x => x.StudentID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassAssignment",
                columns: table => new
                {
                    ClassID = table.Column<string>(nullable: false),
                    SimulationID = table.Column<int>(nullable: false),
                    DateSet = table.Column<DateTime>(nullable: false),
                    DateDue = table.Column<DateTime>(nullable: false),
                    ClassroomClassID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassAssignment", x => new { x.ClassID, x.SimulationID });
                    table.ForeignKey(
                        name: "FK_ClassAssignment_Classroom_ClassroomClassID",
                        column: x => x.ClassroomClassID,
                        principalTable: "Classroom",
                        principalColumn: "ClassID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassAssignment_Simulation_SimulationID",
                        column: x => x.SimulationID,
                        principalTable: "Simulation",
                        principalColumn: "SimulationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentAssignment",
                columns: table => new
                {
                    StudentID = table.Column<string>(nullable: false),
                    SimulationID = table.Column<int>(nullable: false),
                    Percentage = table.Column<int>(nullable: true),
                    DateCompleted = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAssignment", x => new { x.StudentID, x.SimulationID });
                    table.ForeignKey(
                        name: "FK_StudentAssignment_Simulation_SimulationID",
                        column: x => x.SimulationID,
                        principalTable: "Simulation",
                        principalColumn: "SimulationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAssignment_AspNetUsers_StudentID",
                        column: x => x.StudentID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClassroomClassID",
                table: "AspNetUsers",
                column: "ClassroomClassID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassAssignment_ClassroomClassID",
                table: "ClassAssignment",
                column: "ClassroomClassID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassAssignment_SimulationID",
                table: "ClassAssignment",
                column: "SimulationID");

            migrationBuilder.CreateIndex(
                name: "IX_Classroom_TeacherID",
                table: "Classroom",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_ClassroomClassID",
                table: "Enrollment",
                column: "ClassroomClassID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignment_SimulationID",
                table: "StudentAssignment",
                column: "SimulationID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Classroom_ClassroomClassID",
                table: "AspNetUsers",
                column: "ClassroomClassID",
                principalTable: "Classroom",
                principalColumn: "ClassID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Classroom_ClassroomClassID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ClassAssignment");

            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "StudentAssignment");

            migrationBuilder.DropTable(
                name: "Classroom");

            migrationBuilder.DropTable(
                name: "Simulation");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ClassroomClassID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ClassroomClassID",
                table: "AspNetUsers");
        }
    }
}
