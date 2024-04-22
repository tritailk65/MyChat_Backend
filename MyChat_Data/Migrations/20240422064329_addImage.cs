using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyChat_Data.Migrations
{
    public partial class addImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UpImage",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Chat",
                keyColumn: "Chatid",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 4, 22, 13, 43, 28, 641, DateTimeKind.Local).AddTicks(6976));

            migrationBuilder.UpdateData(
                table: "Chat",
                keyColumn: "Chatid",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2024, 4, 22, 13, 43, 28, 641, DateTimeKind.Local).AddTicks(7003));

            migrationBuilder.UpdateData(
                table: "Chat",
                keyColumn: "Chatid",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2024, 4, 22, 13, 43, 28, 641, DateTimeKind.Local).AddTicks(7013));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "92181912-b5e0-4aca-9bcf-436d7047336e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UpImage", "last_seen" },
                values: new object[] { "eca9bb1c-f616-4413-99de-09990046d4e9", "AQAAAAEAACcQAAAAEPwmCvW9rGXCAAsDGpyfW5cwsimeLz1a/QQYQBT3B7hx451j9ZwvVHNV81fu8Dxr1A==", "Image/avatar.jpg", new DateTime(2024, 4, 22, 13, 43, 28, 643, DateTimeKind.Local).AddTicks(3343) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpImage",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Chat",
                keyColumn: "Chatid",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 4, 18, 1, 58, 39, 732, DateTimeKind.Local).AddTicks(3488));

            migrationBuilder.UpdateData(
                table: "Chat",
                keyColumn: "Chatid",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2024, 4, 18, 1, 58, 39, 732, DateTimeKind.Local).AddTicks(3508));

            migrationBuilder.UpdateData(
                table: "Chat",
                keyColumn: "Chatid",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2024, 4, 18, 1, 58, 39, 732, DateTimeKind.Local).AddTicks(3514));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "739cf944-9322-4d9c-aec4-9f45b5ab6182");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "last_seen" },
                values: new object[] { "82dfe41e-b667-4cc3-a77d-550e92cc0c05", "AQAAAAEAACcQAAAAEIfRp7oGSrjxthzX59goZBmM8Q1JasSynNOGUXsluUE+p+9qeRDKp5KBnd2LX7FiOA==", new DateTime(2024, 4, 18, 1, 58, 39, 733, DateTimeKind.Local).AddTicks(4203) });
        }
    }
}
