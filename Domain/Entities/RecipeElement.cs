namespace LazardFreres.CoffeeMachine.Domain.Entities;

public class RecipeElement
{
    public Ingredient Ingredient { get; set; }
    public int Quantity { get; set; }

    public RecipeElement(Ingredient ingredient, int quantity)
    {
        ArgumentNullException.ThrowIfNull(ingredient);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);

        Ingredient = ingredient;
        Quantity = quantity;
    }
}
