using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Present_PresentId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_PresentId",
                table: "Purchase");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseId",
                table: "Present",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Present_PurchaseId",
                table: "Present",
                column: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Present_Purchase_PurchaseId",
                table: "Present",
                column: "PurchaseId",
                principalTable: "Purchase",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Present_Purchase_PurchaseId",
                table: "Present");

            migrationBuilder.DropIndex(
                name: "IX_Present_PurchaseId",
                table: "Present");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "Present");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_PresentId",
                table: "Purchase",
                column: "PresentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Present_PresentId",
                table: "Purchase",
                column: "PresentId",
                principalTable: "Present",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
