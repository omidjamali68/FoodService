using Food.Domain.FoodIngredients.ValueObjects;
using Food.Domain.SeedWork;

namespace Food.Domain.FoodIngredients
{
    public class FoodIngredient : Entity
    {
        private FoodIngredient(Quantity value, int ingredientUnitId, string ingredientTitle, string unitTitle)
        {
            Quantity = value;
            IngredientUnitId = ingredientUnitId;
            IngredientTitle = ingredientTitle;
            UnitTitle = unitTitle;  
        }

        private FoodIngredient() {}

        public Guid FoodId { get; private set; }
        public Domain.Foods.Food Food { get; private set; }
        public int IngredientUnitId { get; private set; }
        public string IngredientTitle { get; private set; }
        public string UnitTitle { get; private set; }
        public Quantity Quantity { get; private set; }

        public static Result<FoodIngredient> Create(double quantity, int ingredientUnitId, string ingredientTitle, string unitTitle)
        {
            var quantityResult = Quantity.Create(quantity);
            if (quantityResult.IsFailure)
                return Result.Failure<FoodIngredient>(quantityResult.Error);

            return new FoodIngredient(quantityResult.Value!, ingredientUnitId, ingredientTitle, unitTitle);
        }
    }
}
