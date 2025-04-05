using Microsoft.EntityFrameworkCore.Migrations;

namespace CarLo.Backend.DAL.Migrations
{
    public partial class returnRequestTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReturnRequestDetails",
                columns: table => new
                {
                    ReturnRequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentalAgreementEntityId = table.Column<int>(nullable: false),
                    ReturnApproval = table.Column<bool>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnRequestDetails", x => x.ReturnRequestId);
                    table.ForeignKey(
                        name: "FK_ReturnRequestDetails_RentalAgreementDetails_RentalAgreementEntityId",
                        column: x => x.RentalAgreementEntityId,
                        principalTable: "RentalAgreementDetails",
                        principalColumn: "AgreementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "104400a8-48be-4c7b-8661-64f32f4b861b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b058b91-466d-4cef-99a6-4b38e2345ed7", "AQAAAAEAACcQAAAAEE9sdnpejNyLrjGYRDCAHZ1i5oG5QK6kKJCLSbS1TG0vub/g59clroKD1ozWBKQxLw==", "e4339c11-a54f-4987-a21e-e346615614e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77b146af-e6b3-47ab-96a9-99b9df9dd53e", "AQAAAAEAACcQAAAAEMc3qzUOfFS8peqc8SLsmRkorhoJbFfEAAovE4sXFXk4VSxJPMtGp9cJ6jjFP+M/WQ==", "f093c430-c181-40d2-ad7f-48d957f1f852" });

            migrationBuilder.CreateIndex(
                name: "IX_ReturnRequestDetails_RentalAgreementEntityId",
                table: "ReturnRequestDetails",
                column: "RentalAgreementEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReturnRequestDetails");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "e9eb5fa0-6673-420c-9393-9961075d2060");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a61581d0-cd48-4cb6-983d-c725947fd92f", "AQAAAAEAACcQAAAAEGQ6VyrV07MQdCuwYsPopWMPeHpOcPaNnsyG5AM9ZmrzZUMxd0Dkrv/I+PSe/F+cag==", "7029fd9e-3d7c-44ab-8856-470d4d351ec1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "217ddd27-2c93-4ad4-b5c1-dd3de8f18da6", "AQAAAAEAACcQAAAAEJWbi3+ImvAtBo22EQTvhmU4VKLx5W/r+i4smcgEyzac1pW4McNlc5tGXXDhXTC9cw==", "ebee05f5-c84f-4d3b-a599-752be5f3627b" });
        }
    }
}
