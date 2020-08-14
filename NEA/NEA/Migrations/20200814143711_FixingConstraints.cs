using Microsoft.EntityFrameworkCore.Migrations;

namespace NEA.Migrations
{
    public partial class FixingConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Classroom_ClassroomClassID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassAssignment_Classroom_ClassroomClassID",
                table: "ClassAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Classroom_AspNetUsers_TeacherID",
                table: "Classroom");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Classroom_ClassroomClassID",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_AspNetUsers_StudentID",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAssignment_AspNetUsers_StudentID",
                table: "StudentAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAssignment",
                table: "StudentAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment");

            migrationBuilder.DropIndex(
                name: "IX_Enrollment_ClassroomClassID",
                table: "Enrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classroom",
                table: "Classroom");

            migrationBuilder.DropIndex(
                name: "IX_Classroom_TeacherID",
                table: "Classroom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassAssignment",
                table: "ClassAssignment");

            migrationBuilder.DropIndex(
                name: "IX_ClassAssignment_ClassroomClassID",
                table: "ClassAssignment");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ClassroomClassID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "StudentAssignment");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "ClassroomClassID",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "ClassID",
                table: "Classroom");

            migrationBuilder.DropColumn(
                name: "TeacherID",
                table: "Classroom");

            migrationBuilder.DropColumn(
                name: "ClassID",
                table: "ClassAssignment");

            migrationBuilder.DropColumn(
                name: "ClassroomClassID",
                table: "ClassAssignment");

            migrationBuilder.DropColumn(
                name: "ClassroomClassID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "StudentAssignment",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ClassID",
                table: "Enrollment",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Enrollment",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClassroomID",
                table: "Enrollment",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "Enrollment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NEAUserId",
                table: "Enrollment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClassroomID",
                table: "Classroom",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Classroom",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClassroomID",
                table: "ClassAssignment",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAssignment",
                table: "StudentAssignment",
                columns: new[] { "UserID", "SimulationID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment",
                columns: new[] { "UserID", "ClassroomID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classroom",
                table: "Classroom",
                column: "ClassroomID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassAssignment",
                table: "ClassAssignment",
                columns: new[] { "ClassroomID", "SimulationID" });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_ClassroomID",
                table: "Enrollment",
                column: "ClassroomID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_NEAUserId",
                table: "Enrollment",
                column: "NEAUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Classroom_UserID",
                table: "Classroom",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassAssignment_Classroom_ClassroomID",
                table: "ClassAssignment",
                column: "ClassroomID",
                principalTable: "Classroom",
                principalColumn: "ClassroomID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Classroom_AspNetUsers_UserID",
                table: "Classroom",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Classroom_ClassroomID",
                table: "Enrollment",
                column: "ClassroomID",
                principalTable: "Classroom",
                principalColumn: "ClassroomID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_AspNetUsers_NEAUserId",
                table: "Enrollment",
                column: "NEAUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_AspNetUsers_UserID",
                table: "Enrollment",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAssignment_AspNetUsers_UserID",
                table: "StudentAssignment",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassAssignment_Classroom_ClassroomID",
                table: "ClassAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Classroom_AspNetUsers_UserID",
                table: "Classroom");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Classroom_ClassroomID",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_AspNetUsers_NEAUserId",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_AspNetUsers_UserID",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAssignment_AspNetUsers_UserID",
                table: "StudentAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAssignment",
                table: "StudentAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment");

            migrationBuilder.DropIndex(
                name: "IX_Enrollment_ClassroomID",
                table: "Enrollment");

            migrationBuilder.DropIndex(
                name: "IX_Enrollment_NEAUserId",
                table: "Enrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classroom",
                table: "Classroom");

            migrationBuilder.DropIndex(
                name: "IX_Classroom_UserID",
                table: "Classroom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassAssignment",
                table: "ClassAssignment");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "StudentAssignment");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "ClassroomID",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "NEAUserId",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "ClassroomID",
                table: "Classroom");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Classroom");

            migrationBuilder.DropColumn(
                name: "ClassroomID",
                table: "ClassAssignment");

            migrationBuilder.AddColumn<string>(
                name: "StudentID",
                table: "StudentAssignment",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ClassID",
                table: "Enrollment",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentID",
                table: "Enrollment",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClassroomClassID",
                table: "Enrollment",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClassID",
                table: "Classroom",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeacherID",
                table: "Classroom",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClassID",
                table: "ClassAssignment",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClassroomClassID",
                table: "ClassAssignment",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClassroomClassID",
                table: "AspNetUsers",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAssignment",
                table: "StudentAssignment",
                columns: new[] { "StudentID", "SimulationID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment",
                columns: new[] { "StudentID", "ClassID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classroom",
                table: "Classroom",
                column: "ClassID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassAssignment",
                table: "ClassAssignment",
                columns: new[] { "ClassID", "SimulationID" });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_ClassroomClassID",
                table: "Enrollment",
                column: "ClassroomClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Classroom_TeacherID",
                table: "Classroom",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassAssignment_ClassroomClassID",
                table: "ClassAssignment",
                column: "ClassroomClassID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClassroomClassID",
                table: "AspNetUsers",
                column: "ClassroomClassID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Classroom_ClassroomClassID",
                table: "AspNetUsers",
                column: "ClassroomClassID",
                principalTable: "Classroom",
                principalColumn: "ClassID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassAssignment_Classroom_ClassroomClassID",
                table: "ClassAssignment",
                column: "ClassroomClassID",
                principalTable: "Classroom",
                principalColumn: "ClassID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Classroom_AspNetUsers_TeacherID",
                table: "Classroom",
                column: "TeacherID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Classroom_ClassroomClassID",
                table: "Enrollment",
                column: "ClassroomClassID",
                principalTable: "Classroom",
                principalColumn: "ClassID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_AspNetUsers_StudentID",
                table: "Enrollment",
                column: "StudentID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAssignment_AspNetUsers_StudentID",
                table: "StudentAssignment",
                column: "StudentID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
