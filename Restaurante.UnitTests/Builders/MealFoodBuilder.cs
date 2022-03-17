using AutoBogus;
using Restaurante.Core.Models;

namespace Restaurante.UnitTests.Builders
{
    public class MealFoodBuilder : AutoFaker<MealFood>
    {
        public MealFoodBuilder() : base("pt_BR")
        {
            var food = new FoodBuilder().Generate();
            var meal = new MealBuilder().Generate();
            RuleFor(x => x.Food, food);
            RuleFor(x => x.Meal, meal);
            RuleFor(x => x.FoodId, food.Id);
            RuleFor(x => x.MealId, meal.Id);
        }
    }
}