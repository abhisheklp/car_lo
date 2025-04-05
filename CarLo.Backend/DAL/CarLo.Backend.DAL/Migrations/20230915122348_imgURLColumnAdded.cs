using Microsoft.EntityFrameworkCore.Migrations;

namespace CarLo.Backend.DAL.Migrations
{
    public partial class imgURLColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarImageURL",
                table: "CarDetails",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarImageURL",
                table: "CarDetails");
        }
    }
}
