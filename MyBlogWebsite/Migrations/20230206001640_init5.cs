using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlogWebsite.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "2092aef4-0ce9-4680-83ea-f7bff65f68e6", "39f33d74-ebe9-48bc-95fd-186c2e38b321", "admin", "ADMIN" },
                    { "664f76e8-d64c-4afc-a128-ede063d53a64", "a4183a57-e3b6-4150-9b13-b63bfd8c4669", "standard", "STANDARD" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2c8f61ae-4020-4faf-8be5-63e7bdfa98d7", 0, "d7333b77-bd07-4c18-b149-e9dcd22e40a7", "ApplicationUser", "admin@admin.com", true, "admin", "admin", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEBQfPonIlL54HpQPVOz5Kzr553JlPdufAyk+EDMQs1Fh1zowwr78V7ldph7jSS9ZSA==", null, false, "622a4c00-2e64-41fb-a9e2-cf071e103232", false, "admin" },
                    { "d5af36cd-4630-454a-a9c4-b710639a180c", 0, "4969f3e3-b247-4d0f-afee-26e22bcf1034", "ApplicationUser", "test@test.com", true, "testName", "testLastName", false, null, "TEST@TEST.COM", "TEST", "AQAAAAEAACcQAAAAEOWZEyaLcISA/YvwpBOCi44hrpiO7rOESzCaJ07Eg0aaXcV41Rt9DuSouWXqiFjGtw==", null, false, "7f525d28-6376-4db1-8c98-7af0577416c6", false, "test" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "2c8f61ae-4020-4faf-8be5-63e7bdfa98d7");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2092aef4-0ce9-4680-83ea-f7bff65f68e6", "2c8f61ae-4020-4faf-8be5-63e7bdfa98d7" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "664f76e8-d64c-4afc-a128-ede063d53a64", "d5af36cd-4630-454a-a9c4-b710639a180c" });

            migrationBuilder.CreateIndex(
                name: "AlternateKey_ApplicationUserId",
                table: "Authors",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "AlternateKey_ApplicationUserId",
                table: "Authors");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2092aef4-0ce9-4680-83ea-f7bff65f68e6", "2c8f61ae-4020-4faf-8be5-63e7bdfa98d7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "664f76e8-d64c-4afc-a128-ede063d53a64", "d5af36cd-4630-454a-a9c4-b710639a180c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2092aef4-0ce9-4680-83ea-f7bff65f68e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "664f76e8-d64c-4afc-a128-ede063d53a64");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2c8f61ae-4020-4faf-8be5-63e7bdfa98d7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5af36cd-4630-454a-a9c4-b710639a180c");

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
    }
}
