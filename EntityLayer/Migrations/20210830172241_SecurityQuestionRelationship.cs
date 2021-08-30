using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLayer.Migrations
{
    public partial class SecurityQuestionRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RC_Profile_Legal_LookUp_Security_Questions_SecurityQuestion1",
                table: "RC_Profile_Legal");

            migrationBuilder.DropForeignKey(
                name: "FK_RC_Profile_Legal_LookUp_Security_Questions_SecurityQuestion2",
                table: "RC_Profile_Legal");

            migrationBuilder.AlterColumn<int>(
                name: "SecurityQuestion2",
                table: "RC_Profile_Legal",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SecurityQuestion1",
                table: "RC_Profile_Legal",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_RC_Profile_Legal_LookUp_Security_Questions_SecurityQuestion1",
                table: "RC_Profile_Legal",
                column: "SecurityQuestion1",
                principalTable: "LookUp_Security_Questions",
                principalColumn: "Question_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RC_Profile_Legal_LookUp_Security_Questions_SecurityQuestion2",
                table: "RC_Profile_Legal",
                column: "SecurityQuestion2",
                principalTable: "LookUp_Security_Questions",
                principalColumn: "Question_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RC_Profile_Legal_LookUp_Security_Questions_SecurityQuestion1",
                table: "RC_Profile_Legal");

            migrationBuilder.DropForeignKey(
                name: "FK_RC_Profile_Legal_LookUp_Security_Questions_SecurityQuestion2",
                table: "RC_Profile_Legal");

            migrationBuilder.AlterColumn<int>(
                name: "SecurityQuestion2",
                table: "RC_Profile_Legal",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SecurityQuestion1",
                table: "RC_Profile_Legal",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
    }
}
