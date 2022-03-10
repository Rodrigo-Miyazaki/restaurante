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

namespace Restaurante.UnitTests.Repositories
{
    public class CompanyRepositoryTests : DataBaseRepositoryConfig
    {
        [Test]
        public void Should_Add_Company()
        {
            var dbIdentifier = GetDbIdentifier();
            var dbName = $"Company_{dbIdentifier}";
            var company = new CompanyBuilder()
                            .Generate();

            var companyDb = (Company)null;
            using (var context = new RestauranteContext(GetOptions(dbName)))
            {
                var repository = new CompanyRepository(context);
                repository.Add(company);
            }

            using (var context = new RestauranteContext(GetOptions(dbName)))
            {
                companyDb = context
                 .Companies.Where(f => f.Id == company.Id)
                 .Include(f => f.Address)
                 .FirstOrDefault();
            }

            companyDb.Should().BeEquivalentTo(company, options => options
                                           .Including(o => o.CNPJ)
                                           .Including(o => o.Id)
                                           .Including(o => o.Name)
                                           .Including(o => o.StateRegistration)
                                           .Including(o => o.Address.Id)
                                           .Including(o => o.Address.Neighborhood)
                                           .Including(o => o.Address.Number)
                                           .Including(o => o.Address.PostalCode)
                                           .Including(o => o.Address.State)
                                           .Including(o => o.Address.Street));
        }

        [Test]
        public void Should_Update_Company()
        {
            var dbIdentifier = GetDbIdentifier();
            var dbName = $"Company_{dbIdentifier}";
            var company = new CompanyBuilder()
                            .Generate();
            var companyDb = (Company)null;

            var updatedCompany = company;
            updatedCompany.Address.PostalCode = "123201-023";

            using (var context = new RestauranteContext(GetOptions(dbName)))
            {
                var repository = new CompanyRepository(context);
                repository.Add(company);
            }

            using (var context = new RestauranteContext(GetOptions(dbName)))
            {
                var repository = new CompanyRepository(context);
                repository.Update(updatedCompany);
            }

            using (var context = new RestauranteContext(GetOptions(dbName)))
            {
                companyDb = context
                 .Companies.Where(f => f.Id == company.Id)
                 .Include(f => f.Address)
                 .FirstOrDefault();
            }

            companyDb.Should().BeEquivalentTo(updatedCompany, options => options
                                           .Including(o => o.CNPJ)
                                           .Including(o => o.Id)
                                           .Including(o => o.Name)
                                           .Including(o => o.StateRegistration)
                                           .Including(o => o.Address.Id)
                                           .Including(o => o.Address.Neighborhood)
                                           .Including(o => o.Address.Number)
                                           .Including(o => o.Address.PostalCode)
                                           .Including(o => o.Address.State)
                                           .Including(o => o.Address.Street));
        }
    }
}