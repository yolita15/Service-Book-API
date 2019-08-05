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

            Provider water = new Provider() { Name = "Water" };
            Provider heating = new Provider() { Name = "Heating" };
            context.AddRange(new List<Provider>() { water, heating });
            context.SaveChanges();

            Department cooling = new Department() { Name = "Cooling", Provider = water };
            Department pipe = new Department() { Name = "Pipe", Provider = water };
            Department ventilation = new Department() { Name = "Ventilation", Provider = water };
            Department maintenance = new Department() { Name = "Maintenance", Provider = water };

            Department fire = new Department() { Name = "Fire", Provider = heating };
            Department electro = new Department() { Name = "Electro", Provider = heating };
            Department telematic = new Department() { Name = "Telematic", Provider = heating };
            Department security = new Department() { Name = "Security", Provider = heating };

            context.Departments.AddRange(new List<Department>() { cooling, pipe, ventilation, maintenance, fire, electro, telematic, security });
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
                    heating, water
                }
            };

            context.Companies.Add(company);
            context.SaveChanges();

            ObjectType building = new ObjectType() { Name = "Building" };
            ObjectType floor = new ObjectType() { Name = "Floor" };
            ObjectType room = new ObjectType() { Name = "Room" };

            context.ObjectTypes.AddRange(new List<ObjectType>() { building, floor, room });
            context.SaveChanges();

            Tfm first = new Tfm() { Name = "Building", Code = "2" };
            context.Tfms.Add(first);
            context.SaveChanges();

            Tfm second = new Tfm() { Name = "Building", Code = "22", ParentId = first.Id };
            context.Tfms.Add(second);
            context.SaveChanges();

            Tfm third = new Tfm() { Name = "Room", Code = "221", ParentId = second.Id };
            context.Tfms.Add(third);
            context.SaveChanges();


            Object icb = new Object() { Name = "ICB", Company = company, Tfm = first, Type = building, ObjectIdentifier = "220675" };
            context.Objects.Add(icb);
            context.SaveChanges();

            Object niproruda = new Object() { Name = "Niproruda", Company = company, ParentId = icb.Id, Tfm = second, Type = building, ObjectIdentifier = "223675" };
            context.Objects.Add(niproruda);
            context.SaveChanges();

            Object A207 = new Object() { Name = "A207", Company = company, ParentId = niproruda.Id, Tfm = third, Type = room, ObjectIdentifier = "220678" };
            context.Objects.Add(A207);
            context.SaveChanges();

            ObjectDepartment icbDep1 = new ObjectDepartment() { Department = fire, Object = icb };
            ObjectDepartment icbDep2 = new ObjectDepartment() { Department = cooling, Object = icb };
            ObjectDepartment icbDep3 = new ObjectDepartment() { Department = maintenance, Object = icb };
            ObjectDepartment icbDep4 = new ObjectDepartment() { Department = telematic, Object = icb };

            ObjectDepartment niprorudaDep1 = new ObjectDepartment() { Department = pipe, Object = niproruda };
            ObjectDepartment niprorudaDep2 = new ObjectDepartment() { Department = ventilation, Object = niproruda };
            ObjectDepartment niprorudaDep3 = new ObjectDepartment() { Department = security, Object = niproruda };
            ObjectDepartment niprorudaDep4 = new ObjectDepartment() { Department = electro, Object = niproruda };

            ObjectDepartment A207Dep1 = new ObjectDepartment() { Department = fire, Object = A207 };
            ObjectDepartment A207Dep2 = new ObjectDepartment() { Department = cooling, Object = A207 };
            context.ObjectDepartments.AddRange(
                new List<ObjectDepartment>()
                {
                    icbDep1, icbDep2, icbDep3, icbDep4, niprorudaDep1, niprorudaDep2, niprorudaDep3, niprorudaDep4, A207Dep1, A207Dep2
                });
            context.SaveChanges();
        }
    }
}
