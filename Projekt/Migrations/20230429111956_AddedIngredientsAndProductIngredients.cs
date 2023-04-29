using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Migrations
{
    /// <inheritdoc />
    public partial class AddedIngredientsAndProductIngredients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Subcategory_Subcategory_id",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_User_User_id",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Subcategory_Categories_Category_id",
                table: "Subcategory");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_Role_id",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subcategory",
                table: "Subcategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Subcategory",
                newName: "Subcategories");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_User_Role_id",
                table: "Users",
                newName: "IX_Users_Role_id");

            migrationBuilder.RenameIndex(
                name: "IX_User_Email",
                table: "Users",
                newName: "IX_Users_Email");

            migrationBuilder.RenameIndex(
                name: "IX_Subcategory_Name",
                table: "Subcategories",
                newName: "IX_Subcategories_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Subcategory_Category_id",
                table: "Subcategories",
                newName: "IX_Subcategories_Category_id");

            migrationBuilder.RenameIndex(
                name: "IX_Role_Name",
                table: "Roles",
                newName: "IX_Roles_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Product_User_id",
                table: "Products",
                newName: "IX_Products_User_id");

            migrationBuilder.RenameIndex(
                name: "IX_Product_Subcategory_id",
                table: "Products",
                newName: "IX_Products_Subcategory_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subcategories",
                table: "Subcategories",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Product_Ingredients",
                columns: table => new
                {
                    Product_id = table.Column<int>(type: "int", nullable: false),
                    Ingredient_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Ingredients", x => new { x.Ingredient_id, x.Product_id });
                    table.ForeignKey(
                        name: "FK_Product_Ingredients_Ingredients_Ingredient_id",
                        column: x => x.Ingredient_id,
                        principalTable: "Ingredients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Ingredients_Products_Product_id",
                        column: x => x.Product_id,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Ingredients_Product_id",
                table: "Product_Ingredients",
                column: "Product_id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropTable(
                name: "Product_Ingredients");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subcategories",
                table: "Subcategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Subcategories",
                newName: "Subcategory");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Role_id",
                table: "User",
                newName: "IX_User_Role_id");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Email",
                table: "User",
                newName: "IX_User_Email");

            migrationBuilder.RenameIndex(
                name: "IX_Subcategories_Name",
                table: "Subcategory",
                newName: "IX_Subcategory_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Subcategories_Category_id",
                table: "Subcategory",
                newName: "IX_Subcategory_Category_id");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_Name",
                table: "Role",
                newName: "IX_Role_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Products_User_id",
                table: "Product",
                newName: "IX_Product_User_id");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Subcategory_id",
                table: "Product",
                newName: "IX_Product_Subcategory_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subcategory",
                table: "Subcategory",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Subcategory_Subcategory_id",
                table: "Product",
                column: "Subcategory_id",
                principalTable: "Subcategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_User_User_id",
                table: "Product",
                column: "User_id",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategory_Categories_Category_id",
                table: "Subcategory",
                column: "Category_id",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_Role_id",
                table: "User",
                column: "Role_id",
                principalTable: "Role",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
