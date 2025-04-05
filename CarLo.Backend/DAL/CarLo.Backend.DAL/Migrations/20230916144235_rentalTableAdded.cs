using Microsoft.EntityFrameworkCore.Migrations;

namespace CarLo.Backend.DAL.Migrations
{
    public partial class rentalTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarAvailibity",
                table: "CarDetails");

            migrationBuilder.AddColumn<int>(
                name: "CarAvailability",
                table: "CarDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RentalAgreementDetails",
                columns: table => new
                {
                    AgreementId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNo = table.Column<string>(maxLength: 10, nullable: false),
                    Address = table.Column<string>(maxLength: 255, nullable: false),
                    NoOfDays = table.Column<int>(nullable: false),
                    LicenseNo = table.Column<string>(nullable: false),
                    CarDetailsEntityId = table.Column<int>(nullable: false),
                    VehicleNo = table.Column<string>(nullable: false),
                    AgreementStatus = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalAgreementDetails", x => x.AgreementId);
                    table.ForeignKey(
                        name: "FK_RentalAgreementDetails_CarDetails_CarDetailsEntityId",
                        column: x => x.CarDetailsEntityId,
                        principalTable: "CarDetails",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentalAgreementDetails_CarDetailsEntityId",
                table: "RentalAgreementDetails",
                column: "CarDetailsEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentalAgreementDetails");

            migrationBuilder.DropColumn(
                name: "CarAvailability",
                table: "CarDetails");

            migrationBuilder.AddColumn<int>(
                name: "CarAvailibity",
                table: "CarDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
