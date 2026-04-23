using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FindersJeepers.Migrations
{
    /// <inheritdoc />
    public partial class AddJeepneyDriver : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Jeepneys");

            migrationBuilder.CreateTable(
                name: "JeepneyDriver",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JeepneyId = table.Column<int>(type: "integer", nullable: false),
                    DriverId = table.Column<int>(type: "integer", nullable: false),
                    AssignedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UnassignedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JeepneyDriver", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JeepneyDriver_Jeepneys_JeepneyId",
                        column: x => x.JeepneyId,
                        principalTable: "Jeepneys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JeepneyDriver_JeepneyId",
                table: "JeepneyDriver",
                column: "JeepneyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JeepneyDriver");

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "Jeepneys",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
