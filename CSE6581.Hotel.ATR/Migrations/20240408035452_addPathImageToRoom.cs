using Microsoft.EntityFrameworkCore.Migrations;

namespace CSE6581.Hotel.ATR.Migrations
{
    public partial class addPathImageToRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PathImage",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathImage",
                table: "Rooms");
        }
    }
}
