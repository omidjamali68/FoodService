using Food.Domain.SeedWork;
using Food.Resource;

namespace Food.Domain.Foods
{
    public class FoodErrors : Error
    {
        public FoodErrors(string code, string message) : base(code, message)
        {
        }

        public static Result NotExist => Create("Foods.NotExist", string.Format(Validation.NotExist, DataDictionary.Food));
    }
}
