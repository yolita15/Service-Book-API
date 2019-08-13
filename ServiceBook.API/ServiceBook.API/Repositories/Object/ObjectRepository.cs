using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ServiceBook.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Object = ServiceBook.API.Entities.Object;

namespace ServiceBook.API.Repositories
{
    public class ObjectRepository : IObjectRepository
    {
        private ServiceBookContext _context;

        public ObjectRepository(ServiceBookContext context)
        {
            _context = context;
        }

        public IEnumerable<Object> GetAll()
        {
            return _context.Objects;
        }

        public Object GetById(Guid objectId)
        {
            return _context.Objects
                .Include(o => o.Company).ThenInclude(c => c.Providers).ThenInclude(p => p.Departments)
                .Include(o => o.Tfm)
                .Include(o => o.Type)
                .Include(o => o.ObjectDepartments).ThenInclude(od => od.Department).ThenInclude(d => d.Provider)
                .Include(o => o.ObjectUsers).ThenInclude(ou => ou.User).ThenInclude(u => u.Type)
                .FirstOrDefault(o => o.Id == objectId);
        }

        public string GetImageUrl(Guid objectId)
        {
            return _context.Objects.Where(o => o.Id == objectId).Select(o => o.ImageName).First();
        }

        public string GetObjectName(Guid objectId)
        {
            return _context.Objects.Where(o => o.Id == objectId).Select(o => o.Name).First();
        }

        public IEnumerable<Object> GetObjectsForCompany(Guid companyId)
        {
            return _context.Objects.Where(o => o.CompanyId == companyId)
                .Include(o => o.Type)
                .Include(o => o.Tfm);
        }

        public bool ObjectExists(Guid id)
        {
            return _context.Objects.Any(o => o.Id == id);
        }

        public void UpdateObject(Object obj, List<Department> departments, int applyForChildren)
        {
            _context.Objects.Attach(obj);
            _context.Entry(obj).Property(o => o.Name).IsModified = true;
            _context.Entry(obj).Property(o => o.ObjectIdentifier).IsModified = true;
            _context.Entry(obj).Property(o => o.Latitude).IsModified = true;
            _context.Entry(obj).Property(o => o.Longitude).IsModified = true;
            _context.Entry(obj).Property(o => o.Comment).IsModified = true;
            _context.Entry(obj).Property(o => o.TfmId).IsModified = true;
            _context.SaveChanges();

            UpdateDepartmentsForObject(obj.Id, departments);
        }

        public void UploadImage(Guid objectId, string name)
        {
            Object currentObject = _context.Objects.FirstOrDefault(o => o.Id == objectId);
            currentObject.ImageName = name;
            _context.Entry(currentObject).Property(o => o.ImageName).IsModified = true;

            _context.SaveChanges();
        }

        public void UpdateDepartmentsForObject(Guid id, List<Department> departments)
        {
            var oldDepartments = _context.ObjectDepartments.Where(od => od.ObjectId == id);
            _context.ObjectDepartments.RemoveRange(oldDepartments);
            for (int i = 0; i < departments.Count; i++)
            {
                _context.ObjectDepartments.Add(new ObjectDepartment() { ObjectId = id, DepartmentId = departments[i].Id });
            }

            _context.SaveChanges();
        }

        public IEnumerable<Object> GetObjectsWithParentId(Guid id)
        {
            return _context.Objects.Where(o => o.ParentId == id);
        }
    }
}
