using ServiceBook.API.Entities;
using System;
using System.Collections.Generic;
using Object = ServiceBook.API.Entities.Object;

namespace ServiceBook.API.Repositories
{
    public interface IObjectRepository : IRepository<Entities.Object>
    {
        IEnumerable<Object> GetObjectsForCompany(Guid id);

        IEnumerable<Department> GetDepartmentsForObject(Guid id);

        bool ObjectExists(Guid id); 

        void UpdateObject(Object obj);
    }
}
