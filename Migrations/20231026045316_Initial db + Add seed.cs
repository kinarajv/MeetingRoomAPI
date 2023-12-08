using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MeetingRoomAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialdbAddseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "RoomEvents",
                columns: table => new
                {
                    RoomEventId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RoomId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomEvents", x => x.RoomEventId);
                    table.ForeignKey(
                        name: "FK_RoomEvents_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Capacity", "Description" },
                values: new object[,]
                {
                    { 1, 1, "RuanganA" },
                    { 2, 1, "RuanganB" },
                    { 3, 1, "RuanganC" }
                });

            migrationBuilder.InsertData(
                table: "RoomEvents",
                columns: new[] { "RoomEventId", "Description", "EndTime", "RoomId", "StartTime" },
                values: new object[,]
                {
                    { 1, "EventRuanganA", new DateTime(2023, 10, 26, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 10, 26, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "EventRuanganA2", new DateTime(2023, 10, 26, 16, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 10, 26, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "EventRuanganA", new DateTime(2023, 10, 26, 14, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2023, 10, 26, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "EventRuanganA2", new DateTime(2023, 10, 26, 16, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2023, 10, 26, 15, 55, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomEvents_RoomId",
                table: "RoomEvents",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomEvents");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
