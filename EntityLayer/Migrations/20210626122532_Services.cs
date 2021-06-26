using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLayer.Migrations
{
    public partial class Services : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RC_Payroll_Service",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Type = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RC_Payroll_Service", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RC_Payroll_ServiceProvider",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Type = table.Column<long>(nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Discription = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RC_Payroll_ServiceProvider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeServices",
                columns: table => new
                {
                    EmployeeServiceId = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    EmployeeId = table.Column<long>(nullable: false),
                    ServiveId = table.Column<long>(nullable: false),
                    ServiveProviderId = table.Column<long>(nullable: false),
                    PaymentOption = table.Column<long>(nullable: false),
                    ServiceAmount = table.Column<double>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeServices", x => x.EmployeeServiceId);
                    table.ForeignKey(
                        name: "FK_EmployeeServices_RC_Partners_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "RC_Partners_Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeServices_RC_Payroll_Service_ServiveId",
                        column: x => x.ServiveId,
                        principalTable: "RC_Payroll_Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeServices_RC_Payroll_ServiceProvider_ServiveProviderId",
                        column: x => x.ServiveProviderId,
                        principalTable: "RC_Payroll_ServiceProvider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeServices_EmployeeId",
                table: "EmployeeServices",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeServices_ServiveId",
                table: "EmployeeServices",
                column: "ServiveId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeServices_ServiveProviderId",
                table: "EmployeeServices",
                column: "ServiveProviderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeServices");

            migrationBuilder.DropTable(
                name: "RC_Payroll_Service");

            migrationBuilder.DropTable(
                name: "RC_Payroll_ServiceProvider");
        }
    }
}
