using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlogWebsite.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "41cd8f9c-3b0d-4994-809a-575a54c7501e", "9387eba3-87f5-4aa4-92c6-fb6c867754f0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "421d0785-5e43-4538-940f-bf1ce011f86c", "b8966187-4341-483d-833a-7d6b9438f90f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41cd8f9c-3b0d-4994-809a-575a54c7501e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "421d0785-5e43-4538-940f-bf1ce011f86c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9387eba3-87f5-4aa4-92c6-fb6c867754f0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b8966187-4341-483d-833a-7d6b9438f90f");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "41cd8f9c-3b0d-4994-809a-575a54c7501e", "53445a83-95a1-4224-a0d6-cba7de9e56f1", "admin", "ADMIN" },
                    { "421d0785-5e43-4538-940f-bf1ce011f86c", "9b879237-4d8b-4154-9de0-58a071e7d225", "standard", "STANDARD" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "9387eba3-87f5-4aa4-92c6-fb6c867754f0", 0, "fd572027-4eb4-4768-9738-7344f86bd44c", "ApplicationUser", "admin@admin.com", true, "admin", "admin", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAED75iVuZ6sdhgAJO5t0mhASL6J7FO8lEMIvBVZqyzVDq5kKdvQOqhhK9/VuIY1KdfA==", null, false, "2994d765-7e78-4d7b-bbe2-14841d5014c6", false, "admin" },
                    { "b8966187-4341-483d-833a-7d6b9438f90f", 0, "7c80c36a-9e7d-4b65-85cb-2930cb2c680c", "ApplicationUser", "test@test.com", true, "testName", "testLastName", false, null, "TEST@TEST.COM", "TEST", "AQAAAAEAACcQAAAAEHDmPMsJ30NPfuxwTid2skYUmnpAbYGVDgO4B8CNyZrDehbx/ZLOOdgIyfpjSGfANw==", null, false, "932b76ea-c227-47fa-8ca1-adddd422cc1a", false, "test" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "9387eba3-87f5-4aa4-92c6-fb6c867754f0");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "41cd8f9c-3b0d-4994-809a-575a54c7501e", "9387eba3-87f5-4aa4-92c6-fb6c867754f0" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "421d0785-5e43-4538-940f-bf1ce011f86c", "b8966187-4341-483d-833a-7d6b9438f90f" });
        }
    }
}
