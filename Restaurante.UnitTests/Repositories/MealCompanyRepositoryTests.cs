using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Restaurante.Core.Models;
using Restaurante.Infrastructure.EntityFramework;
using Restaurante.Infrastructure.Repositories;
using Restaurante.UnitTests.Builders;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurante.UnitTests.Repositories
{
    public class MealCompanyRepositoryTests : DataBaseRepositoryConfig
    {
        [Test]
        public async Task Should_Add_MealCompany()
        {
            var dbIdentifier = GetDbIdentifier();
            var dbName = $"MealCompany_{dbIdentifier}";
            var mealCompany = new MealCompanyBuilder()
                            .Generate();

            var mealCompanyDb = (MealCompany)null;
            using (var context = new RestauranteContext(GetOptions(dbName)))
            {
                var repository = new MealCompanyRepository(context);
                await repository.AddAsync(mealCompany);
            }

            using (var context = new RestauranteContext(GetOptions(dbName)))
            {
                mealCompanyDb = context
                 .MealCompany
                 .Include(x => x.Company)
                 .ThenInclude(x => x.Address)
                 .Include(x => x.Meal)
                 .FirstOrDefault(f => f.MealId == mealCompany.MealId && f.CompanyId == mealCompany.CompanyId);
            }
            mealCompanyDb.Should().BeEquivalentTo(mealCompany, options => options
                                           .IgnoringCyclicReferences());
        }
    }
}