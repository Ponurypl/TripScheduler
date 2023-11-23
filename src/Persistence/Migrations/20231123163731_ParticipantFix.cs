using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Example.TripScheduler.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ParticipantFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_participants_scheduledjourneys_ScheduledJourneyId",
                table: "participants");

            migrationBuilder.DropIndex(
                name: "IX_participants_ScheduledJourneyId",
                table: "participants");

            migrationBuilder.DropColumn(
                name: "ScheduledJourneyId",
                table: "participants");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "drivers",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "cars",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ScheduledJourneyId",
                table: "participants",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "drivers",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "cars",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_participants_ScheduledJourneyId",
                table: "participants",
                column: "ScheduledJourneyId");

            migrationBuilder.AddForeignKey(
                name: "FK_participants_scheduledjourneys_ScheduledJourneyId",
                table: "participants",
                column: "ScheduledJourneyId",
                principalTable: "scheduledjourneys",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
