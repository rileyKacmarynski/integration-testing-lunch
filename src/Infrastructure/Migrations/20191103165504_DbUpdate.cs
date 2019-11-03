using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class DbUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart",
                schema: "dbo",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Order",
                schema: "dbo",
                table: "OrderItem");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Product",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Product",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 500);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart",
                schema: "dbo",
                table: "CartItem",
                column: "CartId",
                principalSchema: "dbo",
                principalTable: "Cart",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order",
                schema: "dbo",
                table: "OrderItem",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart",
                schema: "dbo",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Order",
                schema: "dbo",
                table: "OrderItem");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                schema: "dbo",
                table: "Product",
                type: "int",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<int>(
                name: "Description",
                schema: "dbo",
                table: "Product",
                type: "int",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 500);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart",
                schema: "dbo",
                table: "CartItem",
                column: "CartId",
                principalSchema: "dbo",
                principalTable: "Cart",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order",
                schema: "dbo",
                table: "OrderItem",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
