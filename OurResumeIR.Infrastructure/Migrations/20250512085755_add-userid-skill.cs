using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OurResumeIR.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class adduseridskill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e71053d3-aaec-477b-9652-31837aa0e779");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Skill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "ImageName", "LinkInstagram", "LinkLinkdin", "LinkTelegram", "LinkX", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ResumeFile", "SecurityStamp", "Slug", "TwoFactorEnabled", "UserName", "bio" },
                values: new object[] { "e91270af-28b4-4195-b0e2-86d24b790d65", 0, "20a3a470-1209-4df8-b202-b61267fb45b5", "admin@example.com", true, "Admin User", null, null, null, null, null, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEDezCiQYhoanoZ8YgyTn4ZzzqoDOdX6aAHF0AxS0TcngNBtIHkyTeXL3F9ADXB/0Uw==", null, false, null, "8668b2e6-f7c3-432b-bb00-8ffa49f653ee", null, false, "admin@example.com", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e91270af-28b4-4195-b0e2-86d24b790d65");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Skill");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "ImageName", "LinkInstagram", "LinkLinkdin", "LinkTelegram", "LinkX", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ResumeFile", "SecurityStamp", "Slug", "TwoFactorEnabled", "UserName", "bio" },
                values: new object[] { "e71053d3-aaec-477b-9652-31837aa0e779", 0, "18e583b5-fbb9-4c56-a153-eb0fb20fe8ad", "admin@example.com", true, "Admin User", null, null, null, null, null, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEDtDQm8j0IRG5vsFI8ijjPYBDHPZZ5Ka78b2tmtieZEeIhWJdtVUKGVdVNRxOjkumg==", null, false, null, "f41b7401-4e46-456a-b368-64cfbb07bd01", null, false, "admin@example.com", null });
        }
    }
}
