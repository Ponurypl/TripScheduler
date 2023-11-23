using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Example.TripScheduler.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddPassengersSeat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "passengers_seats",
                table: "scheduledjourneys",
                type: "INTEGER",
                precision: 2,
                scale: 0,
                nullable: false,
                defaultValueSql: "0");

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
            migrationBuilder.DropColumn(
                name: "passengers_seats",
                table: "scheduledjourneys");

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
        }
    }
}
