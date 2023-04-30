using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subcategories_Categories_Category_id",
                table: "Subcategories");

            migrationBuilder.RenameColumn(
                name: "Category_id",
                table: "Subcategories",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Subcategories_Category_id",
                table: "Subcategories",
                newName: "IX_Subcategories_CategoryId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Categories",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategories_Categories_CategoryId",
                table: "Subcategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subcategories_Categories_CategoryId",
                table: "Subcategories");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Subcategories",
                newName: "Category_id");

            migrationBuilder.RenameIndex(
                name: "IX_Subcategories_CategoryId",
                table: "Subcategories",
                newName: "IX_Subcategories_Category_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategories_Categories_Category_id",
                table: "Subcategories",
                column: "Category_id",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
