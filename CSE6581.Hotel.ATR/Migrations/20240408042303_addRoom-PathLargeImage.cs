using Microsoft.EntityFrameworkCore.Migrations;

namespace CSE6581.Hotel.ATR.Migrations
{
    public partial class addRoomPathLargeImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PathLargeImage",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathLargeImage",
                table: "Rooms");
        }
    }
}
