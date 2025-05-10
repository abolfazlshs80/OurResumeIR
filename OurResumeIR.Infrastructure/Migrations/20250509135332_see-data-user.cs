using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OurResumeIR.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedatauser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "ImageName", "LinkInstagram", "LinkLinkdin", "LinkTelegram", "LinkX", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ResumeFile", "SecurityStamp", "Slug", "TwoFactorEnabled", "UserName", "bio" },
                values: new object[] { "e71053d3-aaec-477b-9652-31837aa0e779", 0, "18e583b5-fbb9-4c56-a153-eb0fb20fe8ad", "admin@example.com", true, "Admin User", null, null, null, null, null, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEDtDQm8j0IRG5vsFI8ijjPYBDHPZZ5Ka78b2tmtieZEeIhWJdtVUKGVdVNRxOjkumg==", null, false, null, "f41b7401-4e46-456a-b368-64cfbb07bd01", null, false, "admin@example.com", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e71053d3-aaec-477b-9652-31837aa0e779");
        }
    }
}
