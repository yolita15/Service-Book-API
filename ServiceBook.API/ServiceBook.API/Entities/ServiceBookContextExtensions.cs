using System.Collections.Generic;

namespace ServiceBook.API.Entities
{
    public static class ServiceBookContextExtensions
    {
        public static void EnsureSeedDataForContext(this ServiceBookContext context)
        {
            context.Users.RemoveRange(context.Users);
            context.UserTypes.RemoveRange(context.UserTypes);
            context.SaveChanges();

            Company company = new Company()
            {
                Name = "Kotarakut Rumen EOOD",
                Address = "Sofia, Angel Kunchev 22",
                Website = "https://kotarakutrumen.com",
                OrganizationNumber = "112120229",
                Customer = new User() { FirstName = "Kotarakut", LastName = "Rumen", Type = new UserType() { Name = "Customer" } },
                Providers = new List<Provider>() { new Provider() { Name = "Water" }, new Provider() { Name = "Heating" } }
            };

            context.Companies.Add(company);
            context.SaveChanges();
        }
    }
}
