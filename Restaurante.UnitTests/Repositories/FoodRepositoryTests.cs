using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq.AutoMock;
using NUnit.Framework;
using Restaurante.Core.Models;
using Restaurante.Infrastructure.EntityFramework;
using Restaurante.Infrastructure.Repositories;
using Restaurante.UnitTests.Builders;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurante.UnitTests.Repositories
{
    public class FoodRepositoryTests : DataBaseRepositoryConfig
    {
        [Test]
        public async Task Should_Add_Food()
        {
            var dbIdentifier = GetDbIdentifier();
            var dbName = $"Food_{dbIdentifier}";
            var food = new FoodBuilder()
                            .Generate();

            var foodDb = (Food)null;
            using (var context = new RestauranteContext(GetOptions(dbName)))
            {
                var repository = new FoodRepository(context);
                await repository.AddAsync(food);
            }

            using (var context = new RestauranteContext(GetOptions(dbName)))
            {
                foodDb = context
                 .Foods.FirstOrDefault(f => f.Id == food.Id);
            }
            foodDb.Should().BeEquivalentTo(food);
        }

        [Test]
        public async Task Should_Update_Food()
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
                await repository.AddAsync(food);
            }

            using (var context = new RestauranteContext(GetOptions(dbName)))
            {
                var repository = new FoodRepository(context);
                await repository.UpdateAsync(food);
            }

            using (var context = new RestauranteContext(GetOptions(dbName)))
            {
                foodDb = await context
                 .Foods.FirstOrDefaultAsync(f => f.Id == food.Id);
            }
            foodDb.Should().BeEquivalentTo(updatedFood);
        }

        [Test]
        public async Task Should_GetById_Food()
        {
            var dbIdentifier = GetDbIdentifier();
            var dbName = $"Food_{dbIdentifier}";
            var food = new FoodBuilder()
                            .Generate();

            var foodDb = (Food)null;
            using (var context = new RestauranteContext(GetOptions(dbName)))
            {
                var repository = new FoodRepository(context);
                await repository.AddAsync(food);
            }

            using (var context = new RestauranteContext(GetOptions(dbName)))
            {
                var repository = new FoodRepository(context);
                foodDb = await repository.GetByIdAsync(food.Id);
            }
            foodDb.Should().BeEquivalentTo(food);
        }

        [Test]
        public async Task Should_Delete_Food()
        {
            var dbIdentifier = GetDbIdentifier();
            var dbName = $"Food_{dbIdentifier}";
            var food = new FoodBuilder()
                            .Generate();

            var foodDb = (Food)null;
            using (var context = new RestauranteContext(GetOptions(dbName)))
            {
                var repository = new FoodRepository(context);
                await repository.AddAsync(food);
            }

            using (var context = new RestauranteContext(GetOptions(dbName)))
            {
                var repository = new FoodRepository(context);
                await repository.RemoveAsync(food);
            }

            using (var context = new RestauranteContext(GetOptions(dbName)))
            {
                foodDb = await context.Foods.FirstOrDefaultAsync(f => f.Id == food.Id);
            }
            foodDb.Should().BeNull();
        }
    }
}