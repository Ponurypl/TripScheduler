using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Example.TripScheduler.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false),
                    brand = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    model = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    production_year = table.Column<int>(type: "INTEGER", precision: 4, scale: 0, nullable: false),
                    passenger_seats = table.Column<int>(type: "INTEGER", precision: 2, scale: 0, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "drivers",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false),
                    firstname = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    lastname = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    gender = table.Column<int>(type: "INTEGER", precision: 1, nullable: false),
                    rating = table.Column<double>(type: "REAL", precision: 2, scale: 1, nullable: false),
                    driver_license_since = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drivers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "scheduledjourneys",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    origin = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    destination = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    departure_time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    driver_id = table.Column<int>(type: "INTEGER", nullable: false),
                    car_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scheduledjourneys", x => x.id);
                    table.ForeignKey(
                        name: "FK_scheduledjourneys_cars_car_id",
                        column: x => x.car_id,
                        principalTable: "cars",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_scheduledjourneys_drivers_driver_id",
                        column: x => x.driver_id,
                        principalTable: "drivers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "participants",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ScheduledJourneyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    firstname = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    lastname = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "TEXT", maxLength: 60, nullable: true),
                    phone_number = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    journey_id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_participants", x => x.id);
                    table.ForeignKey(
                        name: "FK_participants_scheduledjourneys_ScheduledJourneyId",
                        column: x => x.ScheduledJourneyId,
                        principalTable: "scheduledjourneys",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_participants_scheduledjourneys_journey_id",
                        column: x => x.journey_id,
                        principalTable: "scheduledjourneys",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_participants_ScheduledJourneyId",
                table: "participants",
                column: "ScheduledJourneyId");

            migrationBuilder.CreateIndex(
                name: "IX_participants_journey_id",
                table: "participants",
                column: "journey_id");

            migrationBuilder.CreateIndex(
                name: "IX_scheduledjourneys_car_id",
                table: "scheduledjourneys",
                column: "car_id");

            migrationBuilder.CreateIndex(
                name: "IX_scheduledjourneys_driver_id",
                table: "scheduledjourneys",
                column: "driver_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "participants");

            migrationBuilder.DropTable(
                name: "scheduledjourneys");

            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "drivers");
        }
    }
}
