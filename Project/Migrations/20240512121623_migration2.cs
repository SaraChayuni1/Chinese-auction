using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailes_Category_CategoryId",
                table: "OrderDetailes");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailes_Customers_CustomerId",
                table: "OrderDetailes");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailes_Donor_DonorId",
                table: "OrderDetailes");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Customers_CustomerId",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_OrderDetailes_PresentId",
                table: "Purchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetailes",
                table: "OrderDetailes");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetailes_CustomerId",
                table: "OrderDetailes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "OrderDetailes");

            migrationBuilder.RenameTable(
                name: "OrderDetailes",
                newName: "Present");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetailes_DonorId",
                table: "Present",
                newName: "IX_Present_DonorId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetailes_CategoryId",
                table: "Present",
                newName: "IX_Present_CategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Purchase",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "0, 1")
                .OldAnnotation("SqlServer:Identity", "71, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Donor",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "0, 1")
                .OldAnnotation("SqlServer:Identity", "4545, 2");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Category",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "0, 1")
                .OldAnnotation("SqlServer:Identity", "370, 3");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Present",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "0, 1")
                .OldAnnotation("SqlServer:Identity", "4545, 2");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Customer",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "0, 1")
                .OldAnnotation("SqlServer:Identity", "100, 100");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Present",
                table: "Present",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

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
                name: "IX_CustomerPresent_PresentId",
                table: "CustomerPresent",
                column: "PresentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Present_Category_CategoryId",
                table: "Present",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Present_Donor_DonorId",
                table: "Present",
                column: "DonorId",
                principalTable: "Donor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Customer_CustomerId",
                table: "Purchase",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Present_PresentId",
                table: "Purchase",
                column: "PresentId",
                principalTable: "Present",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Present_Category_CategoryId",
                table: "Present");

            migrationBuilder.DropForeignKey(
                name: "FK_Present_Donor_DonorId",
                table: "Present");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Customer_CustomerId",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Present_PresentId",
                table: "Purchase");

            migrationBuilder.DropTable(
                name: "CustomerPresent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Present",
                table: "Present");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "Present",
                newName: "OrderDetailes");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_Present_DonorId",
                table: "OrderDetailes",
                newName: "IX_OrderDetailes_DonorId");

            migrationBuilder.RenameIndex(
                name: "IX_Present_CategoryId",
                table: "OrderDetailes",
                newName: "IX_OrderDetailes_CategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Purchase",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "71, 1")
                .OldAnnotation("SqlServer:Identity", "0, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Donor",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "4545, 2")
                .OldAnnotation("SqlServer:Identity", "0, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Category",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "370, 3")
                .OldAnnotation("SqlServer:Identity", "0, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "OrderDetailes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "4545, 2")
                .OldAnnotation("SqlServer:Identity", "0, 1");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "OrderDetailes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Customers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "100, 100")
                .OldAnnotation("SqlServer:Identity", "0, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetailes",
                table: "OrderDetailes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailes_CustomerId",
                table: "OrderDetailes",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailes_Category_CategoryId",
                table: "OrderDetailes",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailes_Customers_CustomerId",
                table: "OrderDetailes",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailes_Donor_DonorId",
                table: "OrderDetailes",
                column: "DonorId",
                principalTable: "Donor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Customers_CustomerId",
                table: "Purchase",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_OrderDetailes_PresentId",
                table: "Purchase",
                column: "PresentId",
                principalTable: "OrderDetailes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
