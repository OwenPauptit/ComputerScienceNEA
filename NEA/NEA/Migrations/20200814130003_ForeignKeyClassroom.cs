using Microsoft.EntityFrameworkCore.Migrations;

namespace NEA.Migrations
{
    public partial class ForeignKeyClassroom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassAssignment_Classroom_ClassroomClassID",
                table: "ClassAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Classroom_ClassroomClassID",
                table: "Enrollment");

            migrationBuilder.DropIndex(
                name: "IX_Enrollment_ClassroomClassID",
                table: "Enrollment");

            migrationBuilder.DropIndex(
                name: "IX_ClassAssignment_ClassroomClassID",
                table: "ClassAssignment");

            migrationBuilder.DropColumn(
                name: "ClassroomClassID",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "ClassroomClassID",
                table: "ClassAssignment");

            migrationBuilder.AlterColumn<string>(
                name: "ClassID",
                table: "Enrollment",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ClassID",
                table: "ClassAssignment",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_ClassID",
                table: "Enrollment",
                column: "ClassID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassAssignment_Classroom_ClassID",
                table: "ClassAssignment",
                column: "ClassID",
                principalTable: "Classroom",
                principalColumn: "ClassID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Classroom_ClassID",
                table: "Enrollment",
                column: "ClassID",
                principalTable: "Classroom",
                principalColumn: "ClassID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassAssignment_Classroom_ClassID",
                table: "ClassAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Classroom_ClassID",
                table: "Enrollment");

            migrationBuilder.DropIndex(
                name: "IX_Enrollment_ClassID",
                table: "Enrollment");

            migrationBuilder.AlterColumn<string>(
                name: "ClassID",
                table: "Enrollment",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AddColumn<string>(
                name: "ClassroomClassID",
                table: "Enrollment",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClassID",
                table: "ClassAssignment",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AddColumn<string>(
                name: "ClassroomClassID",
                table: "ClassAssignment",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_ClassroomClassID",
                table: "Enrollment",
                column: "ClassroomClassID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassAssignment_ClassroomClassID",
                table: "ClassAssignment",
                column: "ClassroomClassID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassAssignment_Classroom_ClassroomClassID",
                table: "ClassAssignment",
                column: "ClassroomClassID",
                principalTable: "Classroom",
                principalColumn: "ClassID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Classroom_ClassroomClassID",
                table: "Enrollment",
                column: "ClassroomClassID",
                principalTable: "Classroom",
                principalColumn: "ClassID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
