namespace Food.Application.Foods.Queries.GetById
{
    public sealed record GetFoodByIdDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public HashSet<FoodIngredientDto>? ingredients { get; set; }
    }

    public sealed record FoodIngredientDto(string IngredinetTitle, string UnitTitle, double Quantity);
}
