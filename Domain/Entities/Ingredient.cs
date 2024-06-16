namespace LazardFreres.CoffeeMachine.Domain.Entities;

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Ingredient(string name, decimal price)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        Name = name;
        Price = price;
    }
}
