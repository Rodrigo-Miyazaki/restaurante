using FluentAssertions;
using Moq.AutoMock;
using NUnit.Framework;
using Restaurante.Core.Models;
using Restaurante.Infrastructure.EntityFramework;
using Restaurante.Infrastructure.Repositories;
using Restaurante.UnitTests.Builders;
using System;
using System.Linq;

namespace Restaurante.UnitTests.Repositories
{
    public class FoodRepositoryTests : DataBaseRepositoryConfig
    {
        [Test]
        public void Add_Should_Add_Food()
        {
            var dbIdentifier = GetDbIdentifier();
            var dbName = $"Food_{dbIdentifier}";
            var food = new FoodBuilder()
                            .Generate();

            var foodDb = (Food)null;
            using (var context = new RestauranteContext(GetOptions(dbName)))
            {
                var repository = new FoodRepository(context);
                repository.Add(food);
            }

            using (var context = new RestauranteContext(GetOptions(dbName)))
            {
                foodDb = context
                 .Foods.FirstOrDefault(f => f.Id == food.Id);
            }
            foodDb.Should().BeEquivalentTo(food);
        }

        [Test]
        public void Update_Should_Update_Food()
        {
            var dbIdentifier = GetDbIdentifier();
            var dbName = $"Food_{dbIdentifier}";
            var food = new FoodBuilder()
                            .Generate();

            var updatedFood = food;
            updatedFood.Name = "updateFood";

            var foodDb = (Food)null;
            using (var context = new RestauranteContext(GetOptions(dbName)))
            {
                var repository = new FoodRepository(context);
                repository.Add(food);
            }

            using (var context = new RestauranteContext(GetOptions(dbName)))
            {
                var repository = new FoodRepository(context);
                repository.Update(food);
            }

            using (var context = new RestauranteContext(GetOptions(dbName)))
            {
                foodDb = context
                 .Foods.FirstOrDefault(f => f.Id == food.Id);
            }
            foodDb.Should().BeEquivalentTo(updatedFood);
        }
    }
}