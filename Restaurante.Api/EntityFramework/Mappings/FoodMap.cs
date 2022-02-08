using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Api.Models;

namespace Restaurante.Api.EntityFramework.Mappings
{
    public class FoodMap : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.ToTable("Foods");
        }
    }
}