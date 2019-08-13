using Microsoft.AspNetCore.Http;
using ServiceBook.API.Entities;
using System;
using System.Collections.Generic;
using Object = ServiceBook.API.Entities.Object;

namespace ServiceBook.API.Repositories
{
    public interface IObjectRepository : IRepository<Object>
    {
        IEnumerable<Object> GetObjectsForCompany(Guid id);

        IEnumerable<Object> GetObjectsWithParentId(Guid id);

        bool ObjectExists(Guid id); 

        void UpdateObject(Object obj, List<Department> departments, int applyForChildren);

        void UpdateDepartmentsForObject(Guid id, List<Department> departments);

        string GetImageUrl(Guid id);

        string GetObjectName(Guid id);

        void UploadImage(Guid id, string name);
    }
}
