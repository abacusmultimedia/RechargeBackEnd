using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLayer.Migrations
{
    public partial class ProfileSecurityInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RC_Profile_Legal_SecurityQuestion1",
                table: "RC_Profile_Legal",
                column: "SecurityQuestion1");

            migrationBuilder.CreateIndex(
                name: "IX_RC_Profile_Legal_SecurityQuestion2",
                table: "RC_Profile_Legal",
                column: "SecurityQuestion2");

            migrationBuilder.AddForeignKey(
                name: "FK_RC_Profile_Legal_LookUp_Security_Questions_SecurityQuestion1",
                table: "RC_Profile_Legal",
                column: "SecurityQuestion1",
                principalTable: "LookUp_Security_Questions",
                principalColumn: "Question_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RC_Profile_Legal_LookUp_Security_Questions_SecurityQuestion2",
                table: "RC_Profile_Legal",
                column: "SecurityQuestion2",
                principalTable: "LookUp_Security_Questions",
                principalColumn: "Question_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RC_Profile_Legal_LookUp_Security_Questions_SecurityQuestion1",
                table: "RC_Profile_Legal");

            migrationBuilder.DropForeignKey(
                name: "FK_RC_Profile_Legal_LookUp_Security_Questions_SecurityQuestion2",
                table: "RC_Profile_Legal");

            migrationBuilder.DropIndex(
                name: "IX_RC_Profile_Legal_SecurityQuestion1",
                table: "RC_Profile_Legal");

            migrationBuilder.DropIndex(
                name: "IX_RC_Profile_Legal_SecurityQuestion2",
                table: "RC_Profile_Legal");
        }
    }
}
