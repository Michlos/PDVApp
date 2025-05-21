using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PDVApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class IncludeProductReferenceInInventoryLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_InventoryLogs_ProductId",
                table: "InventoryLogs",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLogs_Products_ProductId",
                table: "InventoryLogs",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLogs_Products_ProductId",
                table: "InventoryLogs");

            migrationBuilder.DropIndex(
                name: "IX_InventoryLogs_ProductId",
                table: "InventoryLogs");
        }
    }
}
