using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class kkk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Present_PresentId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_PresentToCartDto_Customer_CustomerId",
                table: "PresentToCartDto");

            migrationBuilder.DropIndex(
                name: "IX_PresentToCartDto_CustomerId",
                table: "PresentToCartDto");

            migrationBuilder.DropIndex(
                name: "IX_Customer_PresentId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "PresentToCartDto");

            migrationBuilder.DropColumn(
                name: "PresentId",
                table: "Customer");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_CustomerId",
                table: "Purchase",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Customer_CustomerId",
                table: "Purchase",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Customer_CustomerId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_CustomerId",
                table: "Purchase");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "PresentToCartDto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PresentId",
                table: "Customer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PresentToCartDto_CustomerId",
                table: "PresentToCartDto",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_PresentId",
                table: "Customer",
                column: "PresentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Present_PresentId",
                table: "Customer",
                column: "PresentId",
                principalTable: "Present",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PresentToCartDto_Customer_CustomerId",
                table: "PresentToCartDto",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");
        }
    }
}
