using Food.Domain.SeedWork;
using Food.Domain.ShareKernel.ValueObjects;

namespace Food.Domain.Foods
{
    public class Food : Entity<Guid>
    {        
        public Title Title { get; internal set; }
        public byte[] Image { get; internal set; }
        public HashSet<FoodIngredients.FoodIngredient> Ingredients { get; internal set; }

        private Food() 
        {
            Ingredients = new HashSet<FoodIngredients.FoodIngredient>();
        }

        private Food(Title value, byte[] image)
        {
            Title = value;
            Image = image;
            Ingredients = new HashSet<FoodIngredients.FoodIngredient>();
        }

        public static Result Create(string title, byte[] image)
        {
            var titleResult = Title.Create(title);
            if (titleResult.IsFailure)
                return titleResult.Error;

            return Result.Success(
                new Food(titleResult.Value!, image)
                );
        }
    }
}
