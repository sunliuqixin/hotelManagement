using Microsoft.EntityFrameworkCore.Migrations;

namespace infrastructure.Migrations
{
    public partial class DelectRoomTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_RoomType_RoomTypeId",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_RoomTypeId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "RoomTypeId",
                table: "Room");

            migrationBuilder.CreateIndex(
                name: "IX_Room_RTCode",
                table: "Room",
                column: "RTCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_RoomType_RTCode",
                table: "Room",
                column: "RTCode",
                principalTable: "RoomType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_RoomType_RTCode",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_RTCode",
                table: "Room");

            migrationBuilder.AddColumn<int>(
                name: "RoomTypeId",
                table: "Room",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Room_RoomTypeId",
                table: "Room",
                column: "RoomTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_RoomType_RoomTypeId",
                table: "Room",
                column: "RoomTypeId",
                principalTable: "RoomType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
