using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OurResumeIR.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class addfildPercentageSkillLeveltable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Percentage",
                table: "Skill");

            migrationBuilder.AddColumn<int>(
                name: "Percentage",
                table: "SkillLevel",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Percentage",
                table: "SkillLevel");

            migrationBuilder.AddColumn<int>(
                name: "Percentage",
                table: "Skill",
                type: "int",
                nullable: true);
        }
    }
}
