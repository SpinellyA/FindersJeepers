using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindersJeepers.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTripLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StopId",
                table: "TripLogs",
                newName: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "TripLogs",
                newName: "StopId");
        }
    }
}
