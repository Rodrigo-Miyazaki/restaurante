using System.Collections.Generic;

namespace Restaurante.Core.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public MealType MealType { get; set; }
        public List<Food> Foods { get; set; }
        public Company Company { get; set; }
    }
}