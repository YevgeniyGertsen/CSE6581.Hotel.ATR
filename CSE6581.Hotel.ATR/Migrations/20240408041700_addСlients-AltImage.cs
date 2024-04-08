using Microsoft.EntityFrameworkCore.Migrations;

namespace CSE6581.Hotel.ATR.Migrations
{
    public partial class addСlientsAltImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AltImage",
                table: "Сlients",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AltImage",
                table: "Сlients");
        }
    }
}
