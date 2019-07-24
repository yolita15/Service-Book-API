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
            context.ObjectTypes.RemoveRange(context.ObjectTypes);
            context.Tfms.RemoveRange(context.Tfms);
            context.Objects.RemoveRange(context.Objects);
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

            ObjectType building = new ObjectType() { Name = "Building" };
            ObjectType floor = new ObjectType() { Name = "Floor" };
            ObjectType room = new ObjectType() { Name = "Room" };

            Object icb = new Object() { Name = "ICB", Company = company, Tfm = new Tfm() { Name = "Building", Code = "2" }, Type = building, ObjectIdentifier = "220675" };
            Object niproruda = new Object() { Name = "Niproruda", Company = company, ParentId = icb.Id, Tfm = new Tfm() { Name = "Building", Code = "22" }, Type = building, ObjectIdentifier = "223675" };
            Object A207 = new Object() { Name = "A207", Company = company, ParentId = niproruda.Id, Tfm = new Tfm() { Name = "Room", Code = "221" }, Type = room , ObjectIdentifier = "220678" };
            List<Object> objects = new List<Object>() { icb, niproruda, A207 };

            context.Companies.Add(company);
            context.Objects.AddRange(objects);
            context.SaveChanges();
        }
    }
}
