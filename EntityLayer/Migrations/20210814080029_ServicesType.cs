using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLayer.Migrations
{
    public partial class ServicesType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RC_Payroll_ServiceProvider_ServiceProvider_Type",
                table: "RC_Payroll_ServiceProvider");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceProvider",
                table: "ServiceProvider");

            migrationBuilder.RenameTable(
                name: "ServiceProvider",
                newName: "Service_Provider_Type");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service_Provider_Type",
                table: "Service_Provider_Type",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RC_Payroll_ServiceProvider_Service_Provider_Type_Type",
                table: "RC_Payroll_ServiceProvider",
                column: "Type",
                principalTable: "Service_Provider_Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RC_Payroll_ServiceProvider_Service_Provider_Type_Type",
                table: "RC_Payroll_ServiceProvider");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service_Provider_Type",
                table: "Service_Provider_Type");

            migrationBuilder.RenameTable(
                name: "Service_Provider_Type",
                newName: "ServiceProvider");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceProvider",
                table: "ServiceProvider",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RC_Payroll_ServiceProvider_ServiceProvider_Type",
                table: "RC_Payroll_ServiceProvider",
                column: "Type",
                principalTable: "ServiceProvider",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
