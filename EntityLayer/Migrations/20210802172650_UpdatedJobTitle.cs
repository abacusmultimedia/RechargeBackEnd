using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLayer.Migrations
{
    public partial class UpdatedJobTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Lookup_Job_Title",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Lookup_Job_Title",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Lookup_Job_Title",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Lookup_Job_Title",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Lookup_Job_Title",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Lookup_Job_Title");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Lookup_Job_Title");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Lookup_Job_Title");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Lookup_Job_Title");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Lookup_Job_Title");
        }
    }
}
