using Microsoft.EntityFrameworkCore.Migrations;

namespace CarLo.Backend.DAL.Migrations
{
    public partial class rentalOneColumnChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "AgreementStatus",
                table: "RentalAgreementDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AgreementStatus",
                table: "RentalAgreementDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}
