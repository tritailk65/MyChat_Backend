using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyChat_Data.Migrations
{
    public partial class taiinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Chat",
                keyColumn: "Chatid",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 4, 1, 7, 57, 0, 701, DateTimeKind.Local).AddTicks(9066));

            migrationBuilder.UpdateData(
                table: "Chat",
                keyColumn: "Chatid",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2024, 4, 1, 7, 57, 0, 701, DateTimeKind.Local).AddTicks(9088));

            migrationBuilder.UpdateData(
                table: "Chat",
                keyColumn: "Chatid",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2024, 4, 1, 7, 57, 0, 701, DateTimeKind.Local).AddTicks(9096));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "90e9c98f-1906-4ce9-9504-c1e0913b3a1b");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "last_seen" },
                values: new object[] { "923f6c42-ec67-4dd0-8583-64f14f53fbd0", "AQAAAAEAACcQAAAAELUHgysTrO2H2vGMdfnvtYfmbzBDvJbGlAW5ZcqzrRu2VHtxG63bzFMkOvUd1niT1w==", new DateTime(2024, 4, 1, 7, 57, 0, 703, DateTimeKind.Local).AddTicks(6452) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Chat",
                keyColumn: "Chatid",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 3, 27, 22, 32, 36, 878, DateTimeKind.Local).AddTicks(303));

            migrationBuilder.UpdateData(
                table: "Chat",
                keyColumn: "Chatid",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2024, 3, 27, 22, 32, 36, 878, DateTimeKind.Local).AddTicks(321));

            migrationBuilder.UpdateData(
                table: "Chat",
                keyColumn: "Chatid",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2024, 3, 27, 22, 32, 36, 878, DateTimeKind.Local).AddTicks(328));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "b3c52614-cb40-4add-879f-e76f713ea436");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "last_seen" },
                values: new object[] { "3b7bde25-7f5a-4d24-a81f-10f30ade7976", "AQAAAAEAACcQAAAAEMEx0pfHxvEqebXHI48JbGpKsA4cv8V0bBxM1sgcWdo2tsG2WERUFv/LG1dC8X4xgg==", new DateTime(2024, 3, 27, 22, 32, 36, 879, DateTimeKind.Local).AddTicks(2390) });
        }
    }
}
