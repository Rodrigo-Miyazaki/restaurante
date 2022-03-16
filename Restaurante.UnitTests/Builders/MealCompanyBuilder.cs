using AutoBogus;
using Restaurante.Core.Models;

namespace Restaurante.UnitTests.Builders
{
    public class MealCompanyBuilder : AutoFaker<MealCompany>
    {
        public MealCompanyBuilder() : base("pt_BR")
        {
            var company = new CompanyBuilder().Generate();
            var meal = new MealBuilder().Generate();
            RuleFor(x => x.Company, company);
            RuleFor(x => x.Meal, meal);
            RuleFor(x => x.CompanyId, company.Id);
            RuleFor(x => x.MealId, meal.Id);
        }
    }
}