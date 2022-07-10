using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComissionCalculator.Migrations
{
    public partial class CommisionRulesCleaning : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "FlatComissionRule_Value",
                table: "ComissionRules",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PercentageComissionRule_Value",
                table: "ComissionRules",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TieredComissionRule_IsPerUnit",
                table: "ComissionRules",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TieredComissionRule_IsPercentage",
                table: "ComissionRules",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "ComissionRules",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlatComissionRule_Value",
                table: "ComissionRules");

            migrationBuilder.DropColumn(
                name: "PercentageComissionRule_Value",
                table: "ComissionRules");

            migrationBuilder.DropColumn(
                name: "TieredComissionRule_IsPerUnit",
                table: "ComissionRules");

            migrationBuilder.DropColumn(
                name: "TieredComissionRule_IsPercentage",
                table: "ComissionRules");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "ComissionRules");
        }
    }
}
