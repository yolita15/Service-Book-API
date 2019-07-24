using System.Collections.Generic;

namespace ServiceBook.API.Entities
{
    public static class ServiceBookContextExtensions
    {
        public static void EnsureSeedDataForContext(this ServiceBookContext context)
        {
            context.Companies.RemoveRange(context.Companies);
            context.Users.RemoveRange(context.Users);
            context.UserTypes.RemoveRange(context.UserTypes);
            context.Providers.RemoveRange(context.Providers);
            context.Departments.RemoveRange(context.Departments);
            context.SaveChanges();

            Company company = new Company()
            {
                Name = "Kotarakut Rumen EOOD",
                Address = "Sofia, Angel Kunchev 22",
                Website = "https://kotarakutrumen.com",
                OrganizationNumber = "112120229",
                Customer = new User() { FirstName = "Kotarakut", LastName = "Rumen", Type = new UserType() { Name = "Customer" } },
                Providers = new List<Provider>()
                {
                    new Provider() {
                        Name = "Water",
                        Departments = new List<Department>()
                        {
                            new Department() { Name = "Cooling" },
                            new Department() { Name = "Pipe" },
                            new Department() { Name = "Ventilation" },
                            new Department() { Name = "Maintenance" }
                        }
                    },
                    new Provider()
                    {
                        Name = "Heating",
                        Departments = new List<Department>()
                        {
                            new Department() { Name = "Fire" },
                            new Department() { Name = "Electro" },
                            new Department() { Name = "Telematic"},
                            new Department() { Name = "Security" }
                        }
                    }
                }
            };

            context.Companies.Add(company);
            context.SaveChanges();
        }
    }
}
