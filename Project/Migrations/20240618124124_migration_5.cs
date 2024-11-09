using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class migration_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Present_Purchase_PurchaseId",
                table: "Present");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Customer_CustomerId",
                table: "Purchase");

            migrationBuilder.DropTable(
                name: "CustomerPresent");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_CustomerId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Present_PurchaseId",
                table: "Present");

            migrationBuilder.DropColumn(
                name: "PresentId",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "Present");

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Purchase",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PresentId",
                table: "Customer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PresentToCartDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    PresentID = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresentToCartDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PresentToCartDto_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PresentToCartDto_Purchase_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_PresentId",
                table: "Customer",
                column: "PresentId");

            migrationBuilder.CreateIndex(
                name: "IX_PresentToCartDto_CustomerId",
                table: "PresentToCartDto",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PresentToCartDto_PurchaseId",
                table: "PresentToCartDto",
                column: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Present_PresentId",
                table: "Customer",
                column: "PresentId",
                principalTable: "Present",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Present_PresentId",
                table: "Customer");

            migrationBuilder.DropTable(
                name: "PresentToCartDto");

            migrationBuilder.DropIndex(
                name: "IX_Customer_PresentId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "PresentId",
                table: "Customer");

            migrationBuilder.AddColumn<int>(
                name: "PresentId",
                table: "Purchase",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PurchaseId",
                table: "Present",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomerPresent",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PresentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPresent", x => new { x.CustomerId, x.PresentId });
                    table.ForeignKey(
                        name: "FK_CustomerPresent_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerPresent_Present_PresentId",
                        column: x => x.PresentId,
                        principalTable: "Present",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_CustomerId",
                table: "Purchase",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Present_PurchaseId",
                table: "Present",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPresent_PresentId",
                table: "CustomerPresent",
                column: "PresentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Present_Purchase_PurchaseId",
                table: "Present",
                column: "PurchaseId",
                principalTable: "Purchase",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Customer_CustomerId",
                table: "Purchase",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
