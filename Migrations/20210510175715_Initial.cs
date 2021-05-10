using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightSchedule.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DepartureCityCityId = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    DestinationCityCityId = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LandingTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_Flights_Cities_DepartureCityCityId",
                        column: x => x.DepartureCityCityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_Cities_DestinationCityCityId",
                        column: x => x.DestinationCityCityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_DepartureCityCityId",
                table: "Flights",
                column: "DepartureCityCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_DestinationCityCityId",
                table: "Flights",
                column: "DestinationCityCityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
