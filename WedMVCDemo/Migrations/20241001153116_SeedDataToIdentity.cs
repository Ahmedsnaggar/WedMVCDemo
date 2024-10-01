using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WedMVCDemo.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataToIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTypes_AspNetUsers_MyPropertyId",
                table: "UserTypes");

            migrationBuilder.AlterColumn<string>(
                name: "MyPropertyId",
                table: "UserTypes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "540fa4db-060f-4f1b-b60a-dd199bfe4111", null, "UsersRole", "USERSROLE" },
                    { "540fa4db-060f-4f1b-b60a-dd199bfe4f0b", null, "AdminsRole", "ADMINSROLE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "62fe5285-fd68-4711-ae93-673787f4a111", 0, null, "2c795c5f-880b-45f9-8748-0b7e390224f1", "user@user.com", true, false, null, "USER@USER.COM", "USER", "AQAAAAIAAYagAAAAEOByCJ2W7aA+Rro7g2smP8ZYz7Z4AqhNjSHZmkcZjg9rvlfUunzozx5bmHVNKLISEw==", null, false, "30676a27-bb29-4f68-aee7-44a94a2fcf5c", false, "user" },
                    { "62fe5285-fd68-4711-ae93-673787f4ac66", 0, null, "ea2693c6-e0c5-45c6-a72e-aa4a18e97f25", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEHmtbNMgf2HKm4UJP+i4XcRBw0ldoHp3Ad8ujnJvYkRxwlw3zKo9rx6Vlv4gV81g5Q==", null, false, "49919cf7-841f-487f-9267-3b696928be2d", false, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "540fa4db-060f-4f1b-b60a-dd199bfe4111", "62fe5285-fd68-4711-ae93-673787f4a111" },
                    { "540fa4db-060f-4f1b-b60a-dd199bfe4111", "62fe5285-fd68-4711-ae93-673787f4ac66" },
                    { "540fa4db-060f-4f1b-b60a-dd199bfe4f0b", "62fe5285-fd68-4711-ae93-673787f4ac66" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserTypes_AspNetUsers_MyPropertyId",
                table: "UserTypes",
                column: "MyPropertyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTypes_AspNetUsers_MyPropertyId",
                table: "UserTypes");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "540fa4db-060f-4f1b-b60a-dd199bfe4111", "62fe5285-fd68-4711-ae93-673787f4a111" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "540fa4db-060f-4f1b-b60a-dd199bfe4111", "62fe5285-fd68-4711-ae93-673787f4ac66" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "540fa4db-060f-4f1b-b60a-dd199bfe4f0b", "62fe5285-fd68-4711-ae93-673787f4ac66" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "540fa4db-060f-4f1b-b60a-dd199bfe4111");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "540fa4db-060f-4f1b-b60a-dd199bfe4f0b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4a111");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4ac66");

            migrationBuilder.AlterColumn<string>(
                name: "MyPropertyId",
                table: "UserTypes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTypes_AspNetUsers_MyPropertyId",
                table: "UserTypes",
                column: "MyPropertyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
