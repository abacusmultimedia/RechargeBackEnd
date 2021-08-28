using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLayer.Migrations
{
    public partial class Lookup_Reward : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "RewardId",
                table: "Rewards",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Lookup_Reward",
                columns: table => new
                {
                    RewardId = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RewardName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lookup_Reward", x => x.RewardId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_RewardId",
                table: "Rewards",
                column: "RewardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rewards_Lookup_Reward_RewardId",
                table: "Rewards",
                column: "RewardId",
                principalTable: "Lookup_Reward",
                principalColumn: "RewardId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rewards_Lookup_Reward_RewardId",
                table: "Rewards");

            migrationBuilder.DropTable(
                name: "Lookup_Reward");

            migrationBuilder.DropIndex(
                name: "IX_Rewards_RewardId",
                table: "Rewards");

            migrationBuilder.DropColumn(
                name: "RewardId",
                table: "Rewards");
        }
    }
}
