using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlogWebsite.Migrations
{
    public partial class u1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "acf9adc9-7da0-4547-9744-b8ae84ed29e0", "2afa55df-97de-4a00-a6f9-ec5fd7f6e66b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b63d61d1-caf9-4baa-ad0e-a08ff834e791", "46676c14-3ede-4fd8-818d-eeb9ce003050" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "acf9adc9-7da0-4547-9744-b8ae84ed29e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b63d61d1-caf9-4baa-ad0e-a08ff834e791");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2afa55df-97de-4a00-a6f9-ec5fd7f6e66b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "46676c14-3ede-4fd8-818d-eeb9ce003050");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "60b6a6ac-6043-4c74-8746-1cb3261db0e8", "b7ea7d54-b3ae-4d9f-a84f-150e547159ec", "admin", "ADMIN" },
                    { "6b4b962f-4e04-4ac3-b435-27d38a8593da", "2f3f565d-1b4e-4888-876a-3872d0a042cf", "standard", "STANDARD" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "746aed6e-f1be-42f2-98a5-0537508f69b9", 0, "4b9a06bd-c461-47fe-99f9-c0afb6436859", "ApplicationUser", "test@test.com", true, "testName", "testLastName", false, null, "TEST@TEST.COM", "TEST", "AQAAAAEAACcQAAAAEHJavJrDzDpfGuSfvjdkbNGODPo9oxwJqDsls6iN9vqq85se6nDxZuEZ4dTbZQjA8A==", null, false, "dd611647-2009-431a-9bba-3e43bb87fcb0", false, "test" },
                    { "7b12faa8-65fe-4d2c-8d4d-e0aaab900d42", 0, "891b8629-efc5-49b6-a381-e6e018854401", "ApplicationUser", "admin@admin.com", true, "admin", "admin", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEP9euROzJ6CkdYjEKYgeQ0NXwWrI47OIiQV+9aRarddB7fNsOLUG5oN+xhzyg8Pgdw==", null, false, "58479072-ccb6-4311-92d9-772e71c7269d", false, "admin" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "7b12faa8-65fe-4d2c-8d4d-e0aaab900d42");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6b4b962f-4e04-4ac3-b435-27d38a8593da", "746aed6e-f1be-42f2-98a5-0537508f69b9" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "60b6a6ac-6043-4c74-8746-1cb3261db0e8", "7b12faa8-65fe-4d2c-8d4d-e0aaab900d42" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6b4b962f-4e04-4ac3-b435-27d38a8593da", "746aed6e-f1be-42f2-98a5-0537508f69b9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "60b6a6ac-6043-4c74-8746-1cb3261db0e8", "7b12faa8-65fe-4d2c-8d4d-e0aaab900d42" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60b6a6ac-6043-4c74-8746-1cb3261db0e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b4b962f-4e04-4ac3-b435-27d38a8593da");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "746aed6e-f1be-42f2-98a5-0537508f69b9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b12faa8-65fe-4d2c-8d4d-e0aaab900d42");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "acf9adc9-7da0-4547-9744-b8ae84ed29e0", "f4d97c25-b70d-453d-9309-48e59682315c", "admin", "ADMIN" },
                    { "b63d61d1-caf9-4baa-ad0e-a08ff834e791", "3dddc0a9-42b0-497b-b601-774b0389b0f9", "standard", "STANDARD" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2afa55df-97de-4a00-a6f9-ec5fd7f6e66b", 0, "7f81e8f7-995f-4d05-a0c8-a9f0a2c2540a", "ApplicationUser", "admin@admin.com", true, "admin", "admin", false, null, "ADMIN@ADMIN.COM", "ADMIN", null, null, false, "51d13f42-bff2-4c29-a58a-e5d86522e7e5", false, "admin" },
                    { "46676c14-3ede-4fd8-818d-eeb9ce003050", 0, "581aae27-5ffc-4174-aa81-308371c09bc1", "ApplicationUser", "test@test.com", true, "testName", "testLastName", false, null, "TEST@TEST.COM", "TEST", null, null, false, "d21d6eb9-5f75-4d25-b396-1d2880622060", false, "test" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "2afa55df-97de-4a00-a6f9-ec5fd7f6e66b");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "acf9adc9-7da0-4547-9744-b8ae84ed29e0", "2afa55df-97de-4a00-a6f9-ec5fd7f6e66b" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b63d61d1-caf9-4baa-ad0e-a08ff834e791", "46676c14-3ede-4fd8-818d-eeb9ce003050" });
        }
    }
}
