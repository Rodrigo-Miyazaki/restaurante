using FluentAssertions;
using Moq.AutoMock;
using NUnit.Framework;
using Restaurante.Infrastructure.EntityFramework;
using Restaurante.Infrastructure.Repositories;
using Restaurante.UnitTests.Builders;
using System;
using System.Linq;

namespace Restaurante.UnitTests.Repositories
{
    public class FoodRepositoryTests : DataBaseRepositoryConfig
    {
        private IFoodRepository _foodRepository;
        private AutoMocker _mock;

        [SetUp]
        public void Setup()
        {
            _mock = new AutoMocker();

            var dbIdentifier = GetDbIdentifier();
            var dbName = $"Sku_{dbIdentifier}";
            var context = new RestauranteContext(GetOptions(dbName));
            _mock.Use(context);
            _foodRepository = _mock.CreateInstance<FoodRepository>();
        }

        [Test]
        public void Add_Should_Add_Food()
        {
            var food = new FoodBuilder()
                            .Generate();

            Action add = () => _foodRepository.Add(food);
            add();

            var foodDb = _mock
                .Get<RestauranteContext>()
                .Foods.FirstOrDefault(f => f.Id == food.Id);

            foodDb.Should().BeEquivalentTo(food);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Add_Should_Not_Add_Food_When_Food_Name_Is_NullOrEmpty(string name)
        {
            var food = new FoodBuilder()
                                .WithName(name)
                                .ForDb()
                                .Generate();

            _foodRepository.Add(food);

            var foodDb = _mock
                .Get<RestauranteContext>()
                .Foods.FirstOrDefault(f => f.Name == food.Name);

            foodDb.Should().BeEquivalentTo(food);
        }
    }
}