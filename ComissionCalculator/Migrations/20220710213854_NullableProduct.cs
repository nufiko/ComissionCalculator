using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComissionCalculator.Migrations
{
    public partial class NullableProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComissionRules_Products_ProductId",
                table: "ComissionRules");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ComissionRules",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ComissionRules_Products_ProductId",
                table: "ComissionRules",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComissionRules_Products_ProductId",
                table: "ComissionRules");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ComissionRules",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ComissionRules_Products_ProductId",
                table: "ComissionRules",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
