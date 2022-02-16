using Microsoft.EntityFrameworkCore;
using Restaurante.Infrastructure.EntityFramework;
using System;

namespace Restaurante.UnitTests.Repositories
{
    public class DataBaseRepositoryConfig
    {
        protected static string GetDbIdentifier() => Guid.NewGuid().ToString();

        protected static DbContextOptions<RestauranteContext> GetOptions(string dbName) =>
            new DbContextOptionsBuilder<RestauranteContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
    }
}