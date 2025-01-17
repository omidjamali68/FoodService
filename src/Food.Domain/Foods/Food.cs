﻿using Food.Domain.SeedWork;
using Food.Domain.ShareKernel.ValueObjects;

namespace Food.Domain.Foods
{
    public class Food : Entity<Guid>
    {        
        public Title Title { get; protected set; }
        public string Image { get; protected set; }
        public HashSet<FoodIngredients.FoodIngredient> Ingredients { get; protected set; }

        protected Food() 
        {
            Ingredients = new HashSet<FoodIngredients.FoodIngredient>();
        }

        private Food(Title value, string image)
        {
            Title = value;
            Image = image;
            Ingredients = new HashSet<FoodIngredients.FoodIngredient>();
        }        

        public static Result<Food> Create(string title, string image)
        {
            var titleResult = Title.Create(title);
            if (titleResult.IsFailure)
                return Result.Failure<Food>(titleResult.Error);

            return new Food(titleResult.Value!, image);
        }

        public Result AddIngredient(double quantity, int ingredientUnitId, string ingredientTitle, string unitTitle)
        {
            var ingredient = FoodIngredients.FoodIngredient.Create(quantity, ingredientUnitId, ingredientTitle, unitTitle);
            if (ingredient.IsFailure)
                return ingredient.Error;

            Ingredients.Add(ingredient.Value!);

            return Result.Success();
        }

        public Result Update(string title, string image)
        {
            var food = Create(title, image);

            if (food.IsFailure)
                return food.Error;

            Title = food.Value!.Title;
            image = food.Value!.Image;
            Ingredients = new HashSet<FoodIngredients.FoodIngredient>();

            return Result.Success();
        }
    }
}
