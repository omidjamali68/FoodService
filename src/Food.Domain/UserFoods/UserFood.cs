using Food.Domain.SeedWork;
using Food.Domain.ShareKernel.ValueObjects;

namespace Food.Domain.UserFoods
{
    public class UserFood : Foods.Food
    {
        public string NidUser { get; private set; }

        private UserFood() { }

        private UserFood(string nidUser, Title title, string image)
        {            
            NidUser = nidUser;
            Title = title;
            Image = image;
        }

        public static Result<UserFood> Create(string nidUser, string title, string image)
        {
            var food = Foods.Food.Create(title, image);
            if (food.IsFailure)
                return Result.Failure<UserFood>(food.Error);

            return new UserFood(nidUser, food.Value.Title, food.Value.Image);
        }
    }
}
