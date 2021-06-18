using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLayer.Migrations
{
    public partial class PartnerEmployees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Job_Title",
                columns: table => new
                {
                    key = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job_Title", x => x.key);
                });

            migrationBuilder.CreateTable(
                name: "RC_Partners_Employees",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    F_Name = table.Column<string>(nullable: true),
                    L_Name = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    JobTitle = table.Column<int>(nullable: false),
                    EmployerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RC_Partners_Employees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RC_Partners_Employees_AspNetUsers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RC_Partners_Employees_Job_Title_JobTitle",
                        column: x => x.JobTitle,
                        principalTable: "Job_Title",
                        principalColumn: "key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RC_Partners_Employees_EmployerId",
                table: "RC_Partners_Employees",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_RC_Partners_Employees_JobTitle",
                table: "RC_Partners_Employees",
                column: "JobTitle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RC_Partners_Employees");

            migrationBuilder.DropTable(
                name: "Job_Title");
        }
    }
}
