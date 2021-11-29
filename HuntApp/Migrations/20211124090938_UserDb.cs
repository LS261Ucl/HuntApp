using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserApi.Migrations
{
    public partial class UserDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Weapons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_UserId",
                table: "Weapons",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Users_UserId",
                table: "Weapons",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Users_UserId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_UserId",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Users");
        }
    }
}
