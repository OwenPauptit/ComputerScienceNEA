using Microsoft.EntityFrameworkCore.Migrations;

namespace NEA.Migrations
{
    public partial class uidEnrollment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_AspNetUsers_UserID",
                table: "Enrollment");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Enrollment",
                newName: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_AspNetUsers_UserId",
                table: "Enrollment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_AspNetUsers_UserId",
                table: "Enrollment");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Enrollment",
                newName: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_AspNetUsers_UserID",
                table: "Enrollment",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
