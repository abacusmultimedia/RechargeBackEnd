using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLayer.Migrations
{
    public partial class ServicesUpdation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeServices_RC_Payroll_Service_ServiveId",
                table: "EmployeeServices");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeServices_RC_Payroll_ServiceProvider_ServiveProviderId",
                table: "EmployeeServices");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeServices_ServiveId",
                table: "EmployeeServices");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeServices_ServiveProviderId",
                table: "EmployeeServices");

            migrationBuilder.DropColumn(
                name: "ServiveId",
                table: "EmployeeServices");

            migrationBuilder.DropColumn(
                name: "ServiveProviderId",
                table: "EmployeeServices");

            migrationBuilder.AddColumn<long>(
                name: "ServiceId",
                table: "EmployeeServices",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ServiceProviderId",
                table: "EmployeeServices",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeServices_ServiceId",
                table: "EmployeeServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeServices_ServiceProviderId",
                table: "EmployeeServices",
                column: "ServiceProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeServices_RC_Payroll_Service_ServiceId",
                table: "EmployeeServices",
                column: "ServiceId",
                principalTable: "RC_Payroll_Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeServices_RC_Payroll_ServiceProvider_ServiceProviderId",
                table: "EmployeeServices",
                column: "ServiceProviderId",
                principalTable: "RC_Payroll_ServiceProvider",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeServices_RC_Payroll_Service_ServiceId",
                table: "EmployeeServices");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeServices_RC_Payroll_ServiceProvider_ServiceProviderId",
                table: "EmployeeServices");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeServices_ServiceId",
                table: "EmployeeServices");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeServices_ServiceProviderId",
                table: "EmployeeServices");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "EmployeeServices");

            migrationBuilder.DropColumn(
                name: "ServiceProviderId",
                table: "EmployeeServices");

            migrationBuilder.AddColumn<long>(
                name: "ServiveId",
                table: "EmployeeServices",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ServiveProviderId",
                table: "EmployeeServices",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeServices_ServiveId",
                table: "EmployeeServices",
                column: "ServiveId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeServices_ServiveProviderId",
                table: "EmployeeServices",
                column: "ServiveProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeServices_RC_Payroll_Service_ServiveId",
                table: "EmployeeServices",
                column: "ServiveId",
                principalTable: "RC_Payroll_Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeServices_RC_Payroll_ServiceProvider_ServiveProviderId",
                table: "EmployeeServices",
                column: "ServiveProviderId",
                principalTable: "RC_Payroll_ServiceProvider",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
