using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TraningSessionApi.Migrations
{
    public partial class InitilCrete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClayPigions = table.Column<int>(type: "int", nullable: false),
                    Duble = table.Column<bool>(type: "bit", nullable: false),
                    NumberOfShots = table.Column<int>(type: "int", nullable: false),
                    HowWasPigonHit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sessions");
        }
    }
}
