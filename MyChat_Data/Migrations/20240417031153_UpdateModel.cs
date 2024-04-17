using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyChat_Data.Migrations
{
    public partial class UpdateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chat_Users_UserId",
                table: "Chat");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Chat",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Chat",
                keyColumn: "Chatid",
                keyValue: 1,
                columns: new[] { "UserId", "created_at" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 4, 17, 10, 11, 53, 127, DateTimeKind.Local).AddTicks(1914) });

            migrationBuilder.UpdateData(
                table: "Chat",
                keyColumn: "Chatid",
                keyValue: 2,
                columns: new[] { "UserId", "created_at" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 4, 17, 10, 11, 53, 127, DateTimeKind.Local).AddTicks(1943) });

            migrationBuilder.UpdateData(
                table: "Chat",
                keyColumn: "Chatid",
                keyValue: 3,
                columns: new[] { "UserId", "created_at" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 4, 17, 10, 11, 53, 127, DateTimeKind.Local).AddTicks(1954) });

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "7803526e-59bb-4935-9daf-594acb48e7ef");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "last_seen" },
                values: new object[] { "c08f229c-4c6b-4d6d-b2db-276317ea8e47", "AQAAAAEAACcQAAAAEF939V5qTgijnxYm0CXG9h/ePXVKA2dCYFStBSA/oiifGR7zIJS3+ovRd1MV0A46Dg==", new DateTime(2024, 4, 17, 10, 11, 53, 129, DateTimeKind.Local).AddTicks(17) });

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_Users_UserId",
                table: "Chat",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chat_Users_UserId",
                table: "Chat");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Chat",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "Chat",
                keyColumn: "Chatid",
                keyValue: 1,
                columns: new[] { "UserId", "created_at" },
                values: new object[] { null, new DateTime(2024, 4, 9, 14, 47, 21, 349, DateTimeKind.Local).AddTicks(1635) });

            migrationBuilder.UpdateData(
                table: "Chat",
                keyColumn: "Chatid",
                keyValue: 2,
                columns: new[] { "UserId", "created_at" },
                values: new object[] { null, new DateTime(2024, 4, 9, 14, 47, 21, 349, DateTimeKind.Local).AddTicks(1654) });

            migrationBuilder.UpdateData(
                table: "Chat",
                keyColumn: "Chatid",
                keyValue: 3,
                columns: new[] { "UserId", "created_at" },
                values: new object[] { null, new DateTime(2024, 4, 9, 14, 47, 21, 349, DateTimeKind.Local).AddTicks(1660) });

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "627339fc-dade-4ee4-a7e9-3e8826051591");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "last_seen" },
                values: new object[] { "00f6af2d-6f11-4f2a-a959-fe0d981cae67", "AQAAAAEAACcQAAAAEAIiLPfiAnQVb+erkUSA61xa9phJpTRq6Rxy+3Av+ZTGBPTI9QO5ljJ5FGPBhOQXyA==", new DateTime(2024, 4, 9, 14, 47, 21, 350, DateTimeKind.Local).AddTicks(2364) });

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_Users_UserId",
                table: "Chat",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
