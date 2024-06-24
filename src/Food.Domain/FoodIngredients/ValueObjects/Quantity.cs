using Food.Domain.SeedWork;
using Food.Resource;

namespace Food.Domain.FoodIngredients.ValueObjects
{
    public class Quantity : ValueObject
    {
        public double Value { get; } = 0;

        private Quantity(double value)
        {
            this.Value = value;
        }

        public static Result<Quantity> Create(double quantity)
        {
            if (quantity <= 0)
            {
                Result.Failure<Quantity>(Error.Create(
                    "ValueObjects.Quantity",
                    string.Format(Validation.RegularExpression, DataDictionary.Quantity)));
            }

            return new Quantity(quantity);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
