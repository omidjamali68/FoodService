using Food.Application.Interfaces;

namespace Food.Application.Foods.Commands.Update
{
    public sealed record UpdateFoodCommand(Guid Id, UpdateFoodDto Dto) : ICommand;

    public sealed record UpdateFoodDto
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public HashSet<UpdateFoodIngredinetDto>? ingredients { get; set; }
    }

    public sealed record UpdateFoodIngredinetDto(double Quantity, int IngredientUnitId, string IngredientTitle, string UnitTitle);
}
