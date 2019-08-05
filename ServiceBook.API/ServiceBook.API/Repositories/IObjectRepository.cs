using ServiceBook.API.Entities;
using System;
using System.Collections.Generic;

namespace ServiceBook.API.Repositories
{
    public interface IObjectRepository : IRepository<Entities.Object>
    {
        IEnumerable<Entities.Object> GetObjectsForCompany(Guid id);

        IEnumerable<Department> GetDepartmentsForObject(Guid id);
    }
}
