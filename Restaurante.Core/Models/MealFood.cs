namespace Restaurante.Core.Models
{
    public class MealFood
    {
        public int MealId { get; set; }
        public Meal Meal { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; }
    }
}