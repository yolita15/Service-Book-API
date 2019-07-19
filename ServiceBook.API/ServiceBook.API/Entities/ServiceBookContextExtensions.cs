using System;

namespace ServiceBook.API.Entities
{
    public static class ServiceBookContextExtensions
    {
        public static void EnsureSeedDataForContext(this ServiceBookContext context)
        {
            UserType userType = new UserType() { Name = "Customer" };
            context.UserTypes.Add(userType);
            context.SaveChanges();
        }
    }
}
