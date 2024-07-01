namespace Food.Application.Foods.Commands.Add.Dtos
{
    public sealed record AddFoodDto(string Title, string Image, HashSet<AddFoodIngredientDto> FoodIngredients);    
}
