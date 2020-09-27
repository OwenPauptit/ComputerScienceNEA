using Microsoft.EntityFrameworkCore.Migrations;

namespace NEA.Migrations
{
    public partial class StudentQModelFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuestion_AspNetUsers_UserID",
                table: "StudentQuestion");

            migrationBuilder.DropIndex(
                name: "IX_StudentQuestion_UserID",
                table: "StudentQuestion");

            migrationBuilder.AddColumn<string>(
                name: "NEAUserId",
                table: "StudentQuestion",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuestion_NEAUserId",
                table: "StudentQuestion",
                column: "NEAUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentQuestion_AspNetUsers_NEAUserId",
                table: "StudentQuestion",
                column: "NEAUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuestion_AspNetUsers_NEAUserId",
                table: "StudentQuestion");

            migrationBuilder.DropIndex(
                name: "IX_StudentQuestion_NEAUserId",
                table: "StudentQuestion");

            migrationBuilder.DropColumn(
                name: "NEAUserId",
                table: "StudentQuestion");

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuestion_UserID",
                table: "StudentQuestion",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentQuestion_AspNetUsers_UserID",
                table: "StudentQuestion",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
