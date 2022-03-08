using AutoBogus;
using Bogus.Extensions.Brazil;
using Restaurante.Core.Models;

namespace Restaurante.UnitTests.Builders
{
    public class CompanyBuilder : AutoFaker<Company>
    {
        public CompanyBuilder() : base("pt_BR")
        {
            var address = new AutoFaker<Address>()
            .StrictMode(false)
            .Rules((f, o) =>
            {
                o.Street = f.Address.StreetName();
                o.Number = f.Address.BuildingNumber();
                o.Neighborhood = f.Random.Words();
                o.City = f.Address.City();
                o.State = f.Address.State();
                o.PostalCode = f.Address.ZipCode();
            })
            .Generate();

            RuleFor(x => x.Name, f => f.Company.CompanyName());
            RuleFor(x => x.CNPJ, f => f.Company.Cnpj());
            RuleFor(x => x.StateRegistration, f => f.Random.AlphaNumeric(10));
            RuleFor(x => x.Address, address);
        }

        public CompanyBuilder WithAddress(Address address)
        {
            RuleFor(x => x.Address, address);
            return this;
        }

        public CompanyBuilder ForDb()
        {
            RuleFor(x => x.Id, 0);
            return this;
        }
    }
}