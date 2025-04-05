using Microsoft.EntityFrameworkCore.Migrations;

namespace CarLo.Backend.DAL.Migrations
{
    public partial class seedMethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1", "e9eb5fa0-6673-420c-9393-9961075d2060", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "isAdmin" },
                values: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", 0, "a61581d0-cd48-4cb6-983d-c725947fd92f", "abhishek@gmail.com", false, "Abhishek Pandey User", false, null, "ABHISHEK@GMAIL.COM", "ABHISHEK@GMAIL.COM", "AQAAAAEAACcQAAAAEGQ6VyrV07MQdCuwYsPopWMPeHpOcPaNnsyG5AM9ZmrzZUMxd0Dkrv/I+PSe/F+cag==", "0123456789", false, "7029fd9e-3d7c-44ab-8856-470d4d351ec1", false, "abhishek@gmail.com", false });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "isAdmin" },
                values: new object[] { "b74ddd14-6340-4840-95c2-db12554843e5", 0, "217ddd27-2c93-4ad4-b5c1-dd3de8f18da6", "abhishek@nagarro.com", false, "Abhishek Pandey Admin", false, null, "ABHISHEK@NAGARRO.COM", "ABHISHEK@NAGARRO.COM", "AQAAAAEAACcQAAAAEJWbi3+ImvAtBo22EQTvhmU4VKLx5W/r+i4smcgEyzac1pW4McNlc5tGXXDhXTC9cw==", "9157806213", false, "ebee05f5-c84f-4d3b-a599-752be5f3627b", false, "abhishek@nagarro.com", true });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "b74ddd14-6340-4840-95c2-db12554843e5", "1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "b74ddd14-6340-4840-95c2-db12554843e5", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5");
        }
    }
}
