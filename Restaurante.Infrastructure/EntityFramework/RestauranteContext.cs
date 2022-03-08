using Microsoft.EntityFrameworkCore;
using Restaurante.Core.Models;

namespace Restaurante.Infrastructure.EntityFramework
{
    public class RestauranteContext : DbContext
    {
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<Company> Companies { get; set; }

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