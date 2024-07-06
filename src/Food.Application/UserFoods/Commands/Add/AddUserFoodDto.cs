using Food.Application.Foods.Commands.Add.Dtos;

namespace Food.Application.UserFoods.Commands.Add
{
    public sealed record AddUserFoodDto(string Title, string Image, HashSet<AddFoodIngredientDto> FoodIngredients);
}
