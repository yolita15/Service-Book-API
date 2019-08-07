using ServiceBook.API.Entities;
using System;

namespace ServiceBook.API.Repositories
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        string GetDepartmentImageName(Guid id);
    }
}
