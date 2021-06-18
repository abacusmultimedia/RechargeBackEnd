using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLayer.Migrations
{
    public partial class Lookup_JobTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RC_Partners_Employees_Job_Title_JobTitle",
                table: "RC_Partners_Employees");

            migrationBuilder.DropTable(
                name: "Job_Title");

            migrationBuilder.CreateTable(
                name: "Lookup_Job_Title",
                columns: table => new
                {
                    key = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lookup_Job_Title", x => x.key);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RC_Partners_Employees_Lookup_Job_Title_JobTitle",
                table: "RC_Partners_Employees",
                column: "JobTitle",
                principalTable: "Lookup_Job_Title",
                principalColumn: "key",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RC_Partners_Employees_Lookup_Job_Title_JobTitle",
                table: "RC_Partners_Employees");

            migrationBuilder.DropTable(
                name: "Lookup_Job_Title");

            migrationBuilder.CreateTable(
                name: "Job_Title",
                columns: table => new
                {
                    key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job_Title", x => x.key);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RC_Partners_Employees_Job_Title_JobTitle",
                table: "RC_Partners_Employees",
                column: "JobTitle",
                principalTable: "Job_Title",
                principalColumn: "key",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
