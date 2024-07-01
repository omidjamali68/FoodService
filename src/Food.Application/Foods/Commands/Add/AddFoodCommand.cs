using Food.Application.Foods.Commands.Add.Dtos;
using Food.Application.Interfaces;

namespace Food.Application.Foods.Commands.Add
{
    public sealed record AddFoodCommand(
        string Title, string Image, HashSet<AddFoodIngredientDto> FoodIngredients) : ICommand<Guid>;    
}
