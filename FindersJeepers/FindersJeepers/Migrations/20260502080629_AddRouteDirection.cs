using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindersJeepers.Migrations
{
    /// <inheritdoc />
    public partial class AddRouteDirection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JeepneyDriver_Jeepneys_JeepneyId",
                table: "JeepneyDriver");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JeepneyDriver",
                table: "JeepneyDriver");

            migrationBuilder.RenameTable(
                name: "JeepneyDriver",
                newName: "JeepneyDrivers");

            migrationBuilder.RenameIndex(
                name: "IX_JeepneyDriver_JeepneyId",
                table: "JeepneyDrivers",
                newName: "IX_JeepneyDrivers_JeepneyId");

            migrationBuilder.AddColumn<int>(
                name: "Direction",
                table: "Trips",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "TripLogs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Direction",
                table: "RouteStops",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JeepneyDrivers",
                table: "JeepneyDrivers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JeepneyDrivers_Jeepneys_JeepneyId",
                table: "JeepneyDrivers",
                column: "JeepneyId",
                principalTable: "Jeepneys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JeepneyDrivers_Jeepneys_JeepneyId",
                table: "JeepneyDrivers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JeepneyDrivers",
                table: "JeepneyDrivers");

            migrationBuilder.DropColumn(
                name: "Direction",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "TripLogs");

            migrationBuilder.DropColumn(
                name: "Direction",
                table: "RouteStops");

            migrationBuilder.RenameTable(
                name: "JeepneyDrivers",
                newName: "JeepneyDriver");

            migrationBuilder.RenameIndex(
                name: "IX_JeepneyDrivers_JeepneyId",
                table: "JeepneyDriver",
                newName: "IX_JeepneyDriver_JeepneyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JeepneyDriver",
                table: "JeepneyDriver",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JeepneyDriver_Jeepneys_JeepneyId",
                table: "JeepneyDriver",
                column: "JeepneyId",
                principalTable: "Jeepneys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
