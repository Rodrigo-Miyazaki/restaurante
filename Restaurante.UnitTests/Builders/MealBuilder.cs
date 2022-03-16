using AutoBogus;
using Restaurante.Core.Models;
using System.Collections.Generic;

namespace Restaurante.UnitTests.Builders
{
    public class MealBuilder : AutoFaker<Meal>
    {
        public MealBuilder() : base("pt_BR")
        {
            RuleFor(x => x.Name, f => f.Name.Random.Words());
            RuleFor(x => x.Quantity, f => f.Random.Number(0, 10));
            RuleFor(x => x.Price, f => f.Random.Number(0, 10000));
            RuleFor(x => x.MealType, f => f.PickRandom<MealType>());
            RuleFor(x => x.Foods, (List<Food>)null);
            RuleFor(x => x.Company, (Company)null);
        }
    }
}