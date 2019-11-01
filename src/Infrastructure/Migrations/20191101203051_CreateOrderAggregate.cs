using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class CreateOrderAggregate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart",
                schema: "dbo",
                table: "CartItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Order",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Order",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "OrderId");

            migrationBuilder.CreateTable(
                name: "OrderItem",
                schema: "dbo",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(type: "money", nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_Order",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                schema: "dbo",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                schema: "dbo",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order",
                column: "CustomerId",
                principalSchema: "dbo",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart",
                schema: "dbo",
                table: "CartItem",
                column: "CartId",
                principalSchema: "dbo",
                principalTable: "Cart",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart",
                schema: "dbo",
                table: "CartItem");

            migrationBuilder.DropTable(
                name: "OrderItem",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_CustomerId",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart",
                schema: "dbo",
                table: "CartItem",
                column: "CartId",
                principalSchema: "dbo",
                principalTable: "Cart",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
