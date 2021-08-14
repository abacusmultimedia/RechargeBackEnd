using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLayer.Migrations
{
    public partial class ServicesTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Service_Type",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProvider",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProvider", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RC_Payroll_ServiceProvider_Type",
                table: "RC_Payroll_ServiceProvider",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_RC_Payroll_Service_Type",
                table: "RC_Payroll_Service",
                column: "Type");

            migrationBuilder.AddForeignKey(
                name: "FK_RC_Payroll_Service_Service_Type_Type",
                table: "RC_Payroll_Service",
                column: "Type",
                principalTable: "Service_Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RC_Payroll_ServiceProvider_ServiceProvider_Type",
                table: "RC_Payroll_ServiceProvider",
                column: "Type",
                principalTable: "ServiceProvider",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RC_Payroll_Service_Service_Type_Type",
                table: "RC_Payroll_Service");

            migrationBuilder.DropForeignKey(
                name: "FK_RC_Payroll_ServiceProvider_ServiceProvider_Type",
                table: "RC_Payroll_ServiceProvider");

            migrationBuilder.DropTable(
                name: "Service_Type");

            migrationBuilder.DropTable(
                name: "ServiceProvider");

            migrationBuilder.DropIndex(
                name: "IX_RC_Payroll_ServiceProvider_Type",
                table: "RC_Payroll_ServiceProvider");

            migrationBuilder.DropIndex(
                name: "IX_RC_Payroll_Service_Type",
                table: "RC_Payroll_Service");
        }
    }
}
