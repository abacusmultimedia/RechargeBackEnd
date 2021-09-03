using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLayer.Migrations
{
    public partial class LookUp_CardType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "RC_Profile_CardDetails");

            migrationBuilder.AddColumn<long>(
                name: "CardTypeID",
                table: "RC_Profile_CardDetails",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LookUp_CardType",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CardName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUp_CardType", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RC_Profile_CardDetails_CardTypeID",
                table: "RC_Profile_CardDetails",
                column: "CardTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_RC_Profile_CardDetails_LookUp_CardType_CardTypeID",
                table: "RC_Profile_CardDetails",
                column: "CardTypeID",
                principalTable: "LookUp_CardType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RC_Profile_CardDetails_LookUp_CardType_CardTypeID",
                table: "RC_Profile_CardDetails");

            migrationBuilder.DropTable(
                name: "LookUp_CardType");

            migrationBuilder.DropIndex(
                name: "IX_RC_Profile_CardDetails_CardTypeID",
                table: "RC_Profile_CardDetails");

            migrationBuilder.DropColumn(
                name: "CardTypeID",
                table: "RC_Profile_CardDetails");

            migrationBuilder.AddColumn<long>(
                name: "Type",
                table: "RC_Profile_CardDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
