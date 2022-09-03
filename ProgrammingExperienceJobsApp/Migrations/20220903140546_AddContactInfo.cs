using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingExperienceJobsApp.Migrations
{
    public partial class AddContactInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "JobPost",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "JobPost",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "JobPost");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "JobPost");
        }
    }
}
