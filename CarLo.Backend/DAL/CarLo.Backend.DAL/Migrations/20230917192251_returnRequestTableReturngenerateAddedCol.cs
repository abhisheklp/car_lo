using Microsoft.EntityFrameworkCore.Migrations;

namespace CarLo.Backend.DAL.Migrations
{
    public partial class returnRequestTableReturngenerateAddedCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ReturnRequestGenerate",
                table: "ReturnRequestDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "4b378160-1c68-40d8-a977-ebbfd10ab056");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "017f9b71-f16c-4fd5-b070-1114d7a8c0ce", "AQAAAAEAACcQAAAAEEDp/9TpvdlyqtLoU1kbH3G0Fl8ckc+FNaHPt8OuzS2jShbuI/3SJjRQ0ttng2gTeA==", "5006587f-bdb0-4164-9be6-a70abf1c1273" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8663e035-2eef-41e1-b380-6017ea290aef", "AQAAAAEAACcQAAAAEMc+9NLh1/mA5l95HtCvlNNB0NgRwRKjLbYVlwC6Ms+M35XA+JeHE8zCfY4KHUYOcA==", "466e4a1f-46ec-451e-ab70-111f7862d1de" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReturnRequestGenerate",
                table: "ReturnRequestDetails");

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
        }
    }
}
