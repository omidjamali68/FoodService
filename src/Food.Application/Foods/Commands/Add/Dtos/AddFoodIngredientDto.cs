namespace Food.Application.Foods.Commands.Add.Dtos
{
    public sealed record AddFoodIngredientDto(int ingredientUnitId, double quantity, string ingredientTitle, string unitTitle);
}
