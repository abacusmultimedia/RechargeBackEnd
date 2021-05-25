using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLayer.Migrations
{
    public partial class CategoriesNSubcats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "SubCategory",
                table: "RC_Profile_BusinessInfor",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "Category",
                table: "RC_Profile_BusinessInfor",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "rc_profile_category",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    OrderBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rc_profile_category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "rc_profile_subcategory",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    OrderBy = table.Column<int>(nullable: false),
                    ParentID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rc_profile_subcategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_rc_profile_subcategory_rc_profile_category_ParentID",
                        column: x => x.ParentID,
                        principalTable: "rc_profile_category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RC_Profile_BusinessInfor_SubCategory",
                table: "RC_Profile_BusinessInfor",
                column: "SubCategory");

            migrationBuilder.CreateIndex(
                name: "IX_rc_profile_subcategory_ParentID",
                table: "rc_profile_subcategory",
                column: "ParentID");

            migrationBuilder.AddForeignKey(
                name: "FK_RC_Profile_BusinessInfor_rc_profile_subcategory_SubCategory",
                table: "RC_Profile_BusinessInfor",
                column: "SubCategory",
                principalTable: "rc_profile_subcategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RC_Profile_BusinessInfor_rc_profile_subcategory_SubCategory",
                table: "RC_Profile_BusinessInfor");

            migrationBuilder.DropTable(
                name: "rc_profile_subcategory");

            migrationBuilder.DropTable(
                name: "rc_profile_category");

            migrationBuilder.DropIndex(
                name: "IX_RC_Profile_BusinessInfor_SubCategory",
                table: "RC_Profile_BusinessInfor");

            migrationBuilder.AlterColumn<int>(
                name: "SubCategory",
                table: "RC_Profile_BusinessInfor",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "RC_Profile_BusinessInfor",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
