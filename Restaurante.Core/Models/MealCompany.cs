namespace Restaurante.Core.Models
{
    public class MealCompany
    {
        public int MealId { get; set; }
        public Meal Meal { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}