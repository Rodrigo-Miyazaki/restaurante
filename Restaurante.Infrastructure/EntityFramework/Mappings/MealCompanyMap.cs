using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Core.Models;

namespace Restaurante.Infrastructure.EntityFramework.Mappings
{
    public class MealCompanyMap : IEntityTypeConfiguration<MealCompany>
    {
        public void Configure(EntityTypeBuilder<MealCompany> builder)
        {
            builder
                 .HasOne(x => x.Company)
                 .WithMany()
                 .HasForeignKey(x => x.CompanyId);

            builder
                .HasOne(x => x.Meal)
                .WithMany()
                .HasForeignKey(x => x.MealId);

            builder
                .HasKey(x => new { x.CompanyId, x.MealId });
        }
    }
}