using Microsoft.EntityFrameworkCore;
using Restaurante.Api.Models;

namespace Restaurante.Api.EntityFramework
{
    public class RestauranteContext : DbContext
    {
        public virtual DbSet<Food> Foods { get; set; }

        public RestauranteContext(DbContextOptions<RestauranteContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RestauranteContext).Assembly);
        }
    }
}