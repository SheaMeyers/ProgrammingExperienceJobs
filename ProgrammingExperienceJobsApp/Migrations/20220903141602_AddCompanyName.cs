using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingExperienceJobsApp.Migrations
{
    public partial class AddCompanyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "JobPost",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "JobPost");
        }
    }
}
