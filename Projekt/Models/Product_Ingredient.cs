namespace Projekt.Models
{
    public class Product_Ingredient
    {
        public int ProductId { get; set; }
        public Product? Product { get; } = null!;
        public int IngredientId { get; set; }
        public Ingredient? Ingredient { get; } = null!;
    }
}
