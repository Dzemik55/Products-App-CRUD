using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Migrations
{
    /// <inheritdoc />
    public partial class AllModelsFixedForCRUD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Ingredients_Ingredients_Ingredient_id",
                table: "Product_Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Ingredients_Products_Product_id",
                table: "Product_Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Subcategories_Subcategory_id",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_User_id",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Subcategories_Categories_Category_id",
                table: "Subcategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_Role_id",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Role_id",
                table: "Users",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Role_id",
                table: "Users",
                newName: "IX_Users_RoleId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Subcategories",
                newName: "Id");

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
                table: "Roles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "User_id",
                table: "Products",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Subcategory_id",
                table: "Products",
                newName: "SubcategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_User_id",
                table: "Products",
                newName: "IX_Products_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Subcategory_id",
                table: "Products",
                newName: "IX_Products_SubcategoryId");

            migrationBuilder.RenameColumn(
                name: "Product_id",
                table: "Product_Ingredients",
                newName: "IngredientId");

            migrationBuilder.RenameColumn(
                name: "Ingredient_id",
                table: "Product_Ingredients",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_Ingredients_Product_id",
                table: "Product_Ingredients",
                newName: "IX_Product_Ingredients_IngredientId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Ingredients",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Categories",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Ingredients_Ingredients_IngredientId",
                table: "Product_Ingredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Ingredients_Products_ProductId",
                table: "Product_Ingredients",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Subcategories_SubcategoryId",
                table: "Products",
                column: "SubcategoryId",
                principalTable: "Subcategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategories_Categories_CategoryId",
                table: "Subcategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Ingredients_Ingredients_IngredientId",
                table: "Product_Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Ingredients_Products_ProductId",
                table: "Product_Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Subcategories_SubcategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Subcategories_Categories_CategoryId",
                table: "Subcategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Users",
                newName: "Role_id");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                newName: "IX_Users_Role_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Subcategories",
                newName: "ID");

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
                table: "Roles",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Products",
                newName: "User_id");

            migrationBuilder.RenameColumn(
                name: "SubcategoryId",
                table: "Products",
                newName: "Subcategory_id");

            migrationBuilder.RenameIndex(
                name: "IX_Products_UserId",
                table: "Products",
                newName: "IX_Products_User_id");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SubcategoryId",
                table: "Products",
                newName: "IX_Products_Subcategory_id");

            migrationBuilder.RenameColumn(
                name: "IngredientId",
                table: "Product_Ingredients",
                newName: "Product_id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Product_Ingredients",
                newName: "Ingredient_id");

            migrationBuilder.RenameIndex(
                name: "IX_Product_Ingredients_IngredientId",
                table: "Product_Ingredients",
                newName: "IX_Product_Ingredients_Product_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ingredients",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Ingredients_Ingredients_Ingredient_id",
                table: "Product_Ingredients",
                column: "Ingredient_id",
                principalTable: "Ingredients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Ingredients_Products_Product_id",
                table: "Product_Ingredients",
                column: "Product_id",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Subcategories_Subcategory_id",
                table: "Products",
                column: "Subcategory_id",
                principalTable: "Subcategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_User_id",
                table: "Products",
                column: "User_id",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategories_Categories_Category_id",
                table: "Subcategories",
                column: "Category_id",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_Role_id",
                table: "Users",
                column: "Role_id",
                principalTable: "Roles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
