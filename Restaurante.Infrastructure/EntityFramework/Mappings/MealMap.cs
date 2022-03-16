using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Core.Models;

namespace Restaurante.Infrastructure.EntityFramework.Mappings
{
    public class MealMap : IEntityTypeConfiguration<Meal>
    {
        public void Configure(EntityTypeBuilder<Meal> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(c => c.Price)
                .HasColumnName("price")
                .IsRequired();

            builder.Property(c => c.MealType)
                .HasColumnName("mealType")
                .IsRequired();

            builder.Property(c => c.Quantity)
                .HasColumnName("quantity")
                .IsRequired();

            builder.Ignore(c => c.Foods);
            builder.Ignore(c => c.Company);
        }
    }
}