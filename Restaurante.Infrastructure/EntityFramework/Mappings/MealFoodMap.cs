using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Core.Models;

namespace Restaurante.Infrastructure.EntityFramework.Mappings
{
    public class MealFoodMap : IEntityTypeConfiguration<MealFood>
    {
        public void Configure(EntityTypeBuilder<MealFood> builder)
        {
            builder
                 .HasOne(x => x.Food)
                 .WithMany()
                 .HasForeignKey(x => x.FoodId);

            builder
                .HasOne(x => x.Meal)
                .WithMany()
                .HasForeignKey(x => x.MealId);

            builder
                .HasKey(x => new { x.FoodId, x.MealId });
        }
    }
}