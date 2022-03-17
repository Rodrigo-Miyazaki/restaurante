using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Restaurante.Core.Models;
using Restaurante.Infrastructure.EntityFramework;
using Restaurante.Infrastructure.Repositories;
using Restaurante.UnitTests.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.UnitTests.Repositories
{
    public class MealFoodRepositoryTests : DataBaseRepositoryConfig
    {
        [Test]
        public async Task Should_Add_MealFood()
        {
            var dbIdentifier = GetDbIdentifier();
            var dbName = $"MealFood_{dbIdentifier}";
            var mealFood = new MealFoodBuilder()
                            .Generate();

            var mealFoodDb = (MealFood)null;
            using (var context = new RestauranteContext(GetOptions(dbName)))
            {
                var repository = new MealFoodRepository(context);
                await repository.AddAsync(mealFood);
            }

            using (var context = new RestauranteContext(GetOptions(dbName)))
            {
                mealFoodDb = context
                 .MealFood
                 .Include(x => x.Food)
                 .Include(x => x.Meal)
                 .FirstOrDefault(f => f.MealId == mealFood.MealId && f.FoodId == mealFood.FoodId);
            }
            mealFoodDb.Should().BeEquivalentTo(mealFood, options => options
                                           .IgnoringCyclicReferences());
        }
    }
}