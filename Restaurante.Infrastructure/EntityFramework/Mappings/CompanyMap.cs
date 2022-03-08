using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Core.Models;

namespace Restaurante.Infrastructure.EntityFramework.Mappings
{
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(c => c.CNPJ)
                .HasColumnName("cnpj")
                .IsRequired();

            builder.HasOne(p => p.Address)
            .WithOne(ad => ad.Company)
            .HasForeignKey<Address>(ad => ad.CompanyId);

            builder.ToTable("Companies");
        }
    }
}