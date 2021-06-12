using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLayer.Migrations
{
    public partial class IssuerCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CountryPhotoIdIssuer",
                table: "RC_Profile_Legal",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "Type",
                table: "RC_Profile_CardDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "AccountManagId",
                table: "RC_Profile_BusinessInfor",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RC_Profile_Legal_CountryPhotoIdIssuer",
                table: "RC_Profile_Legal",
                column: "CountryPhotoIdIssuer");

            migrationBuilder.AddForeignKey(
                name: "FK_RC_Profile_Legal_LookUp_Country_CountryPhotoIdIssuer",
                table: "RC_Profile_Legal",
                column: "CountryPhotoIdIssuer",
                principalTable: "LookUp_Country",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RC_Profile_Legal_LookUp_Country_CountryPhotoIdIssuer",
                table: "RC_Profile_Legal");

            migrationBuilder.DropIndex(
                name: "IX_RC_Profile_Legal_CountryPhotoIdIssuer",
                table: "RC_Profile_Legal");

            migrationBuilder.DropColumn(
                name: "CountryPhotoIdIssuer",
                table: "RC_Profile_Legal");

            migrationBuilder.DropColumn(
                name: "AccountManagId",
                table: "RC_Profile_BusinessInfor");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "RC_Profile_CardDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
