using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLayer.Migrations
{
    public partial class Security_Question : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rewards_Lookup_Reward_RewardId",
                table: "Rewards");

            migrationBuilder.AlterColumn<long>(
                name: "RewardId",
                table: "Rewards",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Group",
                table: "LookUp_Security_Questions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Rewards_Lookup_Reward_RewardId",
                table: "Rewards",
                column: "RewardId",
                principalTable: "Lookup_Reward",
                principalColumn: "RewardId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rewards_Lookup_Reward_RewardId",
                table: "Rewards");

            migrationBuilder.DropColumn(
                name: "Group",
                table: "LookUp_Security_Questions");

            migrationBuilder.AlterColumn<long>(
                name: "RewardId",
                table: "Rewards",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Rewards_Lookup_Reward_RewardId",
                table: "Rewards",
                column: "RewardId",
                principalTable: "Lookup_Reward",
                principalColumn: "RewardId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
