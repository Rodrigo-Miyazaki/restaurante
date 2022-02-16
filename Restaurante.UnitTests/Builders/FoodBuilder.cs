using AutoBogus;
using Restaurante.Core.Models;

namespace Restaurante.UnitTests.Builders
{
    public class FoodBuilder : AutoFaker<Food>
    {
        public FoodBuilder() : base("pt_BR")
        {
            RuleFor(x => x.Name, f => f.Name.Random.Words());
        }

        public FoodBuilder WithName(string name)
        {
            RuleFor(x => x.Name, name);
            return this;
        }

        public FoodBuilder ForDb()
        {
            RuleFor(x => x.Id, 0);
            return this;
        }
    }
}