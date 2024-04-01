using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyChat_Data.Migrations
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Chat",
                columns: new[] { "Chatid", "Content", "Participants", "Title", "UserId", "created_at" },
                values: new object[,]
                {
                    { 1, "Xin Chao", 5, "Hackathon", null, new DateTime(2024, 3, 27, 22, 32, 36, 878, DateTimeKind.Local).AddTicks(303) },
                    { 2, "Xin Chao", 5, "Web2", null, new DateTime(2024, 3, 27, 22, 32, 36, 878, DateTimeKind.Local).AddTicks(321) },
                    { 3, "Xin Chao", 5, "Android 2", null, new DateTime(2024, 3, 27, 22, 32, 36, 878, DateTimeKind.Local).AddTicks(328) }
                });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "contact_id", "UserId", "contact_phone" },
                values: new object[,]
                {
                    { 2, new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), "0765184992" },
                    { 3, new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), "0364748018" }
                });

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

            migrationBuilder.InsertData(
                table: "Messenger",
                columns: new[] { "MessengerId", "ChatId", "Constamps", "Content", "status" },
                values: new object[] { 1, 1, new DateTime(2002, 1, 24, 0, 2, 0, 0, DateTimeKind.Unspecified), "Hello", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Chat",
                keyColumn: "Chatid",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Chat",
                keyColumn: "Chatid",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Contact",
                keyColumn: "contact_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contact",
                keyColumn: "contact_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Messenger",
                keyColumn: "MessengerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Chat",
                keyColumn: "Chatid",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "7da2b45a-b97c-4d50-be5a-979e42cf0c29");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "last_seen" },
                values: new object[] { "a5970a17-e99c-42a5-ac9f-4efb892438c6", "AQAAAAEAACcQAAAAEOFx8NQEx2+/ZNKKUHbPvKiAS4mwF7y/0xV5h0iMUp668msYDpEJLM1zAz/Ss6O+Uw==", new DateTime(2024, 3, 27, 22, 12, 13, 595, DateTimeKind.Local).AddTicks(4115) });
        }
    }
}
