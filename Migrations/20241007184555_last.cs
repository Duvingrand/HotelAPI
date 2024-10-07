using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Migrations
{
    /// <inheritdoc />
    public partial class last : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "total_cost",
                table: "bookings");

            migrationBuilder.CreateIndex(
                name: "IX_rooms_room_type_id",
                table: "rooms",
                column: "room_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_rooms_room_types_room_type_id",
                table: "rooms",
                column: "room_type_id",
                principalTable: "room_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rooms_room_types_room_type_id",
                table: "rooms");

            migrationBuilder.DropIndex(
                name: "IX_rooms_room_type_id",
                table: "rooms");

            migrationBuilder.AddColumn<double>(
                name: "total_cost",
                table: "bookings",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
