using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingExperienceJobsApp.Migrations
{
    public partial class ExperienceRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Experience",
                columns: table => new
                {
                    Language = table.Column<int>(type: "integer", nullable: false),
                    Years = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience", x => x.Language);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceJobPost",
                columns: table => new
                {
                    ExperiencesLanguage = table.Column<int>(type: "integer", nullable: false),
                    JobPostsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceJobPost", x => new { x.ExperiencesLanguage, x.JobPostsId });
                    table.ForeignKey(
                        name: "FK_ExperienceJobPost_Experience_ExperiencesLanguage",
                        column: x => x.ExperiencesLanguage,
                        principalTable: "Experience",
                        principalColumn: "Language",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExperienceJobPost_JobPost_JobPostsId",
                        column: x => x.JobPostsId,
                        principalTable: "JobPost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceJobPost_JobPostsId",
                table: "ExperienceJobPost",
                column: "JobPostsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExperienceJobPost");

            migrationBuilder.DropTable(
                name: "Experience");
        }
    }
}
