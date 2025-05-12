using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OurResumeIR.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class adduseridskilllevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e91270af-28b4-4195-b0e2-86d24b790d65");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "SkillLevel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "ImageName", "LinkInstagram", "LinkLinkdin", "LinkTelegram", "LinkX", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ResumeFile", "SecurityStamp", "Slug", "TwoFactorEnabled", "UserName", "bio" },
                values: new object[] { "9ea1523d-081b-463b-9b71-c183cf446fcc", 0, "5b351b22-0b17-47d7-9e47-9d8948de8d94", "admin@example.com", true, "Admin User", null, null, null, null, null, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEEbEGk4Wumy2o4w2ju4nR0lClRZTJSsVapoWR6pW6oNs6NxHNOMSpKfY5wTgknOJdQ==", null, false, null, "af04f781-c127-4f79-93f9-05ef2acfd365", null, false, "admin@example.com", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ea1523d-081b-463b-9b71-c183cf446fcc");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SkillLevel");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "ImageName", "LinkInstagram", "LinkLinkdin", "LinkTelegram", "LinkX", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ResumeFile", "SecurityStamp", "Slug", "TwoFactorEnabled", "UserName", "bio" },
                values: new object[] { "e91270af-28b4-4195-b0e2-86d24b790d65", 0, "20a3a470-1209-4df8-b202-b61267fb45b5", "admin@example.com", true, "Admin User", null, null, null, null, null, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEDezCiQYhoanoZ8YgyTn4ZzzqoDOdX6aAHF0AxS0TcngNBtIHkyTeXL3F9ADXB/0Uw==", null, false, null, "8668b2e6-f7c3-432b-bb00-8ffa49f653ee", null, false, "admin@example.com", null });
        }
    }
}
