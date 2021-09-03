using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLayer.Migrations
{
    public partial class LookUpBank_LookUpFrequency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BnakName",
                table: "RC_Profile_BankingDetails");

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "RC_Payment");

            migrationBuilder.AddColumn<long>(
                name: "BankID",
                table: "RC_Profile_BankingDetails",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FrequencyId",
                table: "RC_Payment",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "LookUp_Bank",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    BankName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUp_Bank", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LookUp_Frequency",
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
                    table.PrimaryKey("PK_LookUp_Frequency", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RC_Profile_BankingDetails_BankID",
                table: "RC_Profile_BankingDetails",
                column: "BankID");

            migrationBuilder.CreateIndex(
                name: "IX_RC_Payment_FrequencyId",
                table: "RC_Payment",
                column: "FrequencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_RC_Payment_LookUp_Frequency_FrequencyId",
                table: "RC_Payment",
                column: "FrequencyId",
                principalTable: "LookUp_Frequency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RC_Profile_BankingDetails_LookUp_Bank_BankID",
                table: "RC_Profile_BankingDetails",
                column: "BankID",
                principalTable: "LookUp_Bank",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RC_Payment_LookUp_Frequency_FrequencyId",
                table: "RC_Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_RC_Profile_BankingDetails_LookUp_Bank_BankID",
                table: "RC_Profile_BankingDetails");

            migrationBuilder.DropTable(
                name: "LookUp_Bank");

            migrationBuilder.DropTable(
                name: "LookUp_Frequency");

            migrationBuilder.DropIndex(
                name: "IX_RC_Profile_BankingDetails_BankID",
                table: "RC_Profile_BankingDetails");

            migrationBuilder.DropIndex(
                name: "IX_RC_Payment_FrequencyId",
                table: "RC_Payment");

            migrationBuilder.DropColumn(
                name: "BankID",
                table: "RC_Profile_BankingDetails");

            migrationBuilder.DropColumn(
                name: "FrequencyId",
                table: "RC_Payment");

            migrationBuilder.AddColumn<string>(
                name: "BnakName",
                table: "RC_Profile_BankingDetails",
                type: "nvarchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Frequency",
                table: "RC_Payment",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
