using Food.Domain.FoodIngredients.ValueObjects;
using Food.Domain.SeedWork;

namespace Food.Domain.FoodIngredients
{
    public class FoodIngredient : Entity
    {
        private FoodIngredient() {}

        public Guid FoodId { get; private set; }
        public Domain.Foods.Food Food { get; private set; }
        public int IngredientUnitId { get; private set; }
        public Quantity Quantity { get; private set; }
    }
}
