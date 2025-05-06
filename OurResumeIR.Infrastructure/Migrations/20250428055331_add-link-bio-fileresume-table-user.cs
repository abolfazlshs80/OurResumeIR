using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OurResumeIR.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class addlinkbiofileresumetableuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkInstagram",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkLinkdin",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkTelegram",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkX",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResumeFile",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "bio",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkInstagram",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LinkLinkdin",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LinkTelegram",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LinkX",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ResumeFile",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "bio",
                table: "AspNetUsers");
        }
    }
}
