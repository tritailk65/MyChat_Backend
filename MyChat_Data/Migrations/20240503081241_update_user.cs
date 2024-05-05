using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyChat_Data.Migrations
{
    public partial class update_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Chat",
                keyColumn: "Chatid",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 5, 3, 15, 12, 40, 744, DateTimeKind.Local).AddTicks(3717));

            migrationBuilder.UpdateData(
                table: "Chat",
                keyColumn: "Chatid",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2024, 5, 3, 15, 12, 40, 744, DateTimeKind.Local).AddTicks(3736));

            migrationBuilder.UpdateData(
                table: "Chat",
                keyColumn: "Chatid",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2024, 5, 3, 15, 12, 40, 744, DateTimeKind.Local).AddTicks(3741));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "5f2e16a8-a26a-4259-ba49-4789b6f3decd");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "last_seen" },
                values: new object[] { "a2c016cf-f40c-45a7-9e85-4a29ab693155", "AQAAAAEAACcQAAAAEFD7olzOJGnMZ121CvtRPTNg+Fp5Bvr9lFkRa3OWvasRgweprgsDbLiZBASsBNLmqA==", new DateTime(2024, 5, 3, 15, 12, 40, 745, DateTimeKind.Local).AddTicks(6657) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Chat",
                keyColumn: "Chatid",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 5, 3, 15, 8, 25, 514, DateTimeKind.Local).AddTicks(5283));

            migrationBuilder.UpdateData(
                table: "Chat",
                keyColumn: "Chatid",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2024, 5, 3, 15, 8, 25, 514, DateTimeKind.Local).AddTicks(5299));

            migrationBuilder.UpdateData(
                table: "Chat",
                keyColumn: "Chatid",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2024, 5, 3, 15, 8, 25, 514, DateTimeKind.Local).AddTicks(5305));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "8ded65cd-123e-4c00-af02-1fafb99f13a2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "last_seen" },
                values: new object[] { "65b697d6-3a69-41f9-8a73-44e333d7d495", "AQAAAAEAACcQAAAAEIGBZBmNlLqQP20DdsUDD2dfHhJGFSj6hXdOrxjjhzxTnJoRNja2NHnWCLywaS+TNw==", new DateTime(2024, 5, 3, 15, 8, 25, 515, DateTimeKind.Local).AddTicks(8250) });
        }
    }
}
