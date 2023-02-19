using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlogWebsite.Migrations
{
    public partial class asd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4320b19a-b43d-4905-b2ef-fa3b7b6830f4", "079fdb55-73ba-47fe-b547-a04941b6ffa8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9cede53f-0e37-4013-81e5-92057bede6b2", "b0defaf2-03f0-489a-9eae-d71cbadf9d97" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4320b19a-b43d-4905-b2ef-fa3b7b6830f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9cede53f-0e37-4013-81e5-92057bede6b2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "079fdb55-73ba-47fe-b547-a04941b6ffa8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b0defaf2-03f0-489a-9eae-d71cbadf9d97");

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Authors",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2023, 2, 19, 22, 0, 26, 726, DateTimeKind.Local).AddTicks(4620));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2023, 2, 19, 22, 0, 26, 726, DateTimeKind.Local).AddTicks(4622));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2023, 2, 19, 22, 0, 26, 726, DateTimeKind.Local).AddTicks(4624));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3191dc6e-7903-44b8-93dd-31a2d321e8e6", "259a5fce-e717-4f47-8a62-010773cd0bef", "standard", "STANDARD" },
                    { "62b13597-f198-49db-a17d-45dad83e662b", "9ecc2b99-7cca-44a8-9904-f365cd54f643", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "d4abbae3-48e7-4ade-bcff-22c2e9037ecf", 0, "c4cb84e7-9f98-43f7-8464-83085a1df1a4", "ApplicationUser", "admin@admin.com", true, "admin", "admin", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEOZNUaLiufMfCxEBpgP7ZmcYLN6tjjwJmHr0xLLZUK8Ao8hwwkmYKt4IMgc4xcrnNQ==", null, false, "9dce7e71-747f-4c2c-a2ac-2e85bab723a4", false, "admin" },
                    { "fafeb74f-f520-42bd-a266-6c9d7adade29", 0, "0161c75a-a867-46f8-b43f-769d758fe26b", "ApplicationUser", "test@test.com", true, "testName", "testLastName", false, null, "TEST@TEST.COM", "TEST", "AQAAAAEAACcQAAAAEBVnLGUOWu7ZqgHXqcXCrjowkcXKLagJzwVizCYGJv6E2I//4hieelIJMzFbl5gUog==", null, false, "16060b1b-99f6-4b61-bff2-266a0ad85dd5", false, "test" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "d4abbae3-48e7-4ade-bcff-22c2e9037ecf");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "62b13597-f198-49db-a17d-45dad83e662b", "d4abbae3-48e7-4ade-bcff-22c2e9037ecf" },
                    { "3191dc6e-7903-44b8-93dd-31a2d321e8e6", "fafeb74f-f520-42bd-a266-6c9d7adade29" }
                });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "ApplicationUserId",
                value: "d4abbae3-48e7-4ade-bcff-22c2e9037ecf");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "62b13597-f198-49db-a17d-45dad83e662b", "d4abbae3-48e7-4ade-bcff-22c2e9037ecf" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3191dc6e-7903-44b8-93dd-31a2d321e8e6", "fafeb74f-f520-42bd-a266-6c9d7adade29" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3191dc6e-7903-44b8-93dd-31a2d321e8e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62b13597-f198-49db-a17d-45dad83e662b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d4abbae3-48e7-4ade-bcff-22c2e9037ecf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fafeb74f-f520-42bd-a266-6c9d7adade29");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Authors");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2023, 2, 12, 16, 53, 29, 182, DateTimeKind.Local).AddTicks(9093));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2023, 2, 12, 16, 53, 29, 182, DateTimeKind.Local).AddTicks(9096));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2023, 2, 12, 16, 53, 29, 182, DateTimeKind.Local).AddTicks(9098));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4320b19a-b43d-4905-b2ef-fa3b7b6830f4", "c0a196bc-69fc-4914-a238-d33ea2f6ff24", "standard", "STANDARD" },
                    { "9cede53f-0e37-4013-81e5-92057bede6b2", "5e23814c-08e7-40ec-bba2-901c5fa2226f", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "079fdb55-73ba-47fe-b547-a04941b6ffa8", 0, "9e0f8380-d8fb-45c4-a683-eaafc9ea9463", "ApplicationUser", "test@test.com", true, "testName", "testLastName", false, null, "TEST@TEST.COM", "TEST", "AQAAAAEAACcQAAAAEKBZzhDc+WwRYs6ZGab4R6ZI27gUpq7dxe7C2n++Juc1T62koomEUP57OTxbiL98Fg==", null, false, "e7351f93-c140-4209-a86b-d8341a32306d", false, "test" },
                    { "b0defaf2-03f0-489a-9eae-d71cbadf9d97", 0, "e4444754-3b2d-42b3-aaa6-cbd54e2e1001", "ApplicationUser", "admin@admin.com", true, "admin", "admin", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEPteiDX7m8cSga1g+efQ0/M0V5p0NBpDc/3p/yA3E1HMsv4Hqr/zrxSJx2EubGtoZw==", null, false, "4d828d25-528b-446c-b853-d197ea66bf2d", false, "admin" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "b0defaf2-03f0-489a-9eae-d71cbadf9d97");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "4320b19a-b43d-4905-b2ef-fa3b7b6830f4", "079fdb55-73ba-47fe-b547-a04941b6ffa8" },
                    { "9cede53f-0e37-4013-81e5-92057bede6b2", "b0defaf2-03f0-489a-9eae-d71cbadf9d97" }
                });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "ApplicationUserId",
                value: "b0defaf2-03f0-489a-9eae-d71cbadf9d97");
        }
    }
}
