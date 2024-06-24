using Food.Domain.FoodIngredients.ValueObjects;
using Food.Domain.SeedWork;

namespace Food.Domain.FoodIngredients
{
    public class FoodIngredient : Entity
    {
        private FoodIngredient() {}

        public Guid FoodId { get; internal set; }
        public Domain.Foods.Food Food { get; internal set; }
        public int IngredientUnitId { get; internal set; }
        public Quantity Quantity { get; internal set; }
    }
}
