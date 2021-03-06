﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace NEA.Migrations
{
    public partial class RemoveEnrollmentCollectionUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_AspNetUsers_NEAUserId1",
                table: "Enrollment");

            migrationBuilder.DropIndex(
                name: "IX_Enrollment_NEAUserId1",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "NEAUserId1",
                table: "Enrollment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NEAUserId1",
                table: "Enrollment",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_NEAUserId1",
                table: "Enrollment",
                column: "NEAUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_AspNetUsers_NEAUserId1",
                table: "Enrollment",
                column: "NEAUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
