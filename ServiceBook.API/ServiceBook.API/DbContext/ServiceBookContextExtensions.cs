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
            context.ObjectUsers.RemoveRange(context.ObjectUsers);
            context.Tfms.RemoveRange(context.Tfms);
            context.Objects.RemoveRange(context.Objects);
            context.SaveChanges();
            
            UserType objResponsible = new UserType() { Name = "Object Responsible" };
            UserType objDevReponsible = new UserType() { Name = "Object Dev. Responsible" };
            context.UserTypes.AddRange(new List<UserType>() { objDevReponsible, objResponsible });
            context.SaveChanges();

            User rumen = new User() { FirstName = "Kotarakut", LastName = "Rumen", Type = objResponsible };
            User lava = new User() { FirstName = "Lava", LastName = "The Brith", Type = objResponsible };
            User zlatin = new User() { FirstName = "Zlatin", LastName = "Razsadnikov", Type = objDevReponsible };
            User oscar = new User() { FirstName = "King", LastName = "Oscar", Type = objDevReponsible };
            User arya = new User() { FirstName = "Arya", LastName = "The Siamese", Type = objDevReponsible };
            User tom = new User() { FirstName = "Tom", LastName = "The Persian", Type = objDevReponsible };
            context.Users.AddRange(new List<User>() { rumen, lava, zlatin });
            context.SaveChanges();

            Provider water = new Provider() { Name = "Water" };
            Provider heating = new Provider() { Name = "Heating" };
            context.Providers.AddRange(new List<Provider>() { water, heating });
            context.SaveChanges();

            Department cooling = new Department() { Name = "Cooling", Provider = water, ImageName = "cooling.png" };
            Department pipe = new Department() { Name = "Pipe", Provider = water, ImageName = "pipe.png" };
            Department ventilation = new Department() { Name = "Ventilation", Provider = water, ImageName = "ventilation.png" };
            Department maintenance = new Department() { Name = "Maintenance", Provider = water, ImageName = "maint.png" };

            Department fire = new Department() { Name = "Fire", Provider = heating, ImageName = "fire.png" };
            Department electro = new Department() { Name = "Electro", Provider = heating, ImageName = "electro.png" };
            Department telematic = new Department() { Name = "Telematic", Provider = heating, ImageName = "telematics.png" };
            Department security = new Department() { Name = "Security", Provider = heating, ImageName = "security.png" };

            context.Departments.AddRange(new List<Department>() { cooling, pipe, ventilation, maintenance, fire, electro, telematic, security });
            context.SaveChanges();

            Company company = new Company()
            {
                Name = "Kotarakut Rumen EOOD",
                Address = "Sofia, Angel Kunchev 22",
                Website = "https://kotarakutrumen.com",
                OrganizationNumber = "112120229",
                ImageName = "logo.jpg",
                Customer = rumen,
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


            Object icb = new Object() { Name = "ICB", Company = company, Tfm = first, Type = building, ObjectIdentifier = "220675", ImageName = "logo.jpg" };
            context.Objects.Add(icb);
            context.SaveChanges();

            Object niproruda = new Object() { Name = "Niproruda", Company = company, ParentId = icb.Id, Tfm = second, Type = building, ObjectIdentifier = "223675", ImageName = "logo.jpg" };
            context.Objects.Add(niproruda);
            context.SaveChanges();

            Object A207 = new Object() { Name = "A207", Company = company, ParentId = niproruda.Id, Tfm = third, Type = room, ObjectIdentifier = "220678", ImageName = "logo.jpg" };
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

            ObjectUser objUser1 = new ObjectUser() { Object = icb, User = lava };
            ObjectUser objUser2 = new ObjectUser() { Object = icb, User = zlatin };

            ObjectUser objUser3 = new ObjectUser() { Object = niproruda, User = lava };
            ObjectUser objUser4 = new ObjectUser() { Object = niproruda, User = zlatin };

            ObjectUser objUser5 = new ObjectUser() { Object = A207, User = lava };
            ObjectUser objUser6 = new ObjectUser() { Object = A207, User = zlatin };
            context.ObjectUsers.AddRange(
                new List<ObjectUser>()
                {
                    objUser1, objUser2, objUser3, objUser4, objUser5, objUser6
                });
            context.SaveChanges();

        }
    }
}
