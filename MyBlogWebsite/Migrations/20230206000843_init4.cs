using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlogWebsite.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Authors_ApplicationUserId",
                table: "Authors");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "39bd9c43-435e-49f7-9bc3-87b42753713b", "551fcb48-1799-431d-b43e-30a12f386bae" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "750f2ed2-6050-4c8e-a57e-0ec8b567f076", "6dbdca6b-7b42-4225-99e2-2ddbe8158195" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39bd9c43-435e-49f7-9bc3-87b42753713b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "750f2ed2-6050-4c8e-a57e-0ec8b567f076");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "551fcb48-1799-431d-b43e-30a12f386bae");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6dbdca6b-7b42-4225-99e2-2ddbe8158195");

            migrationBuilder.AddUniqueConstraint(
                name: "AlternateKey_ApplicationUserId",
                table: "Authors",
                column: "ApplicationUserId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f457983-347c-4473-8914-c1bfac6449a6", "d751f966-38df-436a-b149-acea04151ffa", "standard", "STANDARD" },
                    { "ebed7a7f-c6c2-4af2-887e-4f4cfead9fc7", "a7acf69a-f97b-46fd-9a97-0d17229ad873", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5686d1ee-c63c-4034-bce2-cbf6cef1d28c", 0, "ae34911c-98b6-4af5-a311-0330284aa907", "ApplicationUser", "test@test.com", true, "testName", "testLastName", false, null, "TEST@TEST.COM", "TEST", "AQAAAAEAACcQAAAAENYmppgZUzQgWdElvsJOffH1/J1128VEb0iC6LUPehxXaKpYfY0LdejNO+vxRhn+pw==", null, false, "2af8d8d1-187d-4cc5-a94a-8a164c5bfa63", false, "test" },
                    { "afeaa625-04e4-4542-b790-6e667523dd93", 0, "053f3c97-074a-480e-b635-0d0dd64e14ab", "ApplicationUser", "admin@admin.com", true, "admin", "admin", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAENf8fSZELwsXnYjVhE8K2o0AV6/T/BadD+hcmOk/IZ2zJWg8qVIR3aRbLCnwJNrztg==", null, false, "7b6c54c3-40b5-4feb-9c41-ad96085ff410", false, "admin" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "afeaa625-04e4-4542-b790-6e667523dd93");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1f457983-347c-4473-8914-c1bfac6449a6", "5686d1ee-c63c-4034-bce2-cbf6cef1d28c" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ebed7a7f-c6c2-4af2-887e-4f4cfead9fc7", "afeaa625-04e4-4542-b790-6e667523dd93" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AlternateKey_ApplicationUserId",
                table: "Authors");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1f457983-347c-4473-8914-c1bfac6449a6", "5686d1ee-c63c-4034-bce2-cbf6cef1d28c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ebed7a7f-c6c2-4af2-887e-4f4cfead9fc7", "afeaa625-04e4-4542-b790-6e667523dd93" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f457983-347c-4473-8914-c1bfac6449a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebed7a7f-c6c2-4af2-887e-4f4cfead9fc7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5686d1ee-c63c-4034-bce2-cbf6cef1d28c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "afeaa625-04e4-4542-b790-6e667523dd93");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39bd9c43-435e-49f7-9bc3-87b42753713b", "b9243e6e-9937-4705-8c51-2fb852fb2830", "admin", "ADMIN" },
                    { "750f2ed2-6050-4c8e-a57e-0ec8b567f076", "d07ba8cf-fe58-4a1e-8b27-2305ee5bc2ae", "standard", "STANDARD" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "551fcb48-1799-431d-b43e-30a12f386bae", 0, "5b746602-0fe7-485e-8b67-d1fdd2461327", "ApplicationUser", "admin@admin.com", true, "admin", "admin", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEH5N2qrXIn08pTHuF6MeHFZUUXwpZRz3Vz5o4alZCa62ByMMf5dBarTrPO1rI4EELA==", null, false, "f76a93a6-9dc3-468e-a2c4-7072232ed5be", false, "admin" },
                    { "6dbdca6b-7b42-4225-99e2-2ddbe8158195", 0, "f36da922-37d3-427a-890f-b7c8e15058b2", "ApplicationUser", "test@test.com", true, "testName", "testLastName", false, null, "TEST@TEST.COM", "TEST", "AQAAAAEAACcQAAAAEAMt1kZoor+02h3ej6xWADS+RNY76GIV8x0VG+YB9UdsdjZcBYqVVpTcXpf419ofxA==", null, false, "f775dc92-17af-4b96-9af5-bab140639a71", false, "test" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "551fcb48-1799-431d-b43e-30a12f386bae");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "39bd9c43-435e-49f7-9bc3-87b42753713b", "551fcb48-1799-431d-b43e-30a12f386bae" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "750f2ed2-6050-4c8e-a57e-0ec8b567f076", "6dbdca6b-7b42-4225-99e2-2ddbe8158195" });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_ApplicationUserId",
                table: "Authors",
                column: "ApplicationUserId",
                unique: true);
        }
    }
}
