using Microsoft.EntityFrameworkCore;
using ServiceBook.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Object = ServiceBook.API.Entities.Object;

namespace ServiceBook.API.Repositories
{
    public class ObjectRepository : IRepository<Entities.Object>, IObjectRepository
    {
        private ServiceBookContext _context;

        public ObjectRepository(ServiceBookContext context)
        {
            _context = context;
        }

        public IEnumerable<Entities.Object> GetAll()
        {
            return _context.Objects;
        }

        public Object GetById(Guid objectId)
        {
            return _context.Objects
                .Include(o => o.Company).ThenInclude(c => c.Providers).ThenInclude(p => p.Departments)
                .Include(o => o.Tfm)
                .Include(o => o.Type)
                .FirstOrDefault(o => o.Id == objectId);
        }

        public IEnumerable<Department> GetDepartmentsForObject(Guid id)
        {
            return _context.ObjectDepartments.Where(o => o.ObjectId == id)
                .Select(d => d.Department).Include(d => d.Provider);
        }

        public IEnumerable<Object> GetObjectsForCompany(Guid companyId)
        {
            return _context.Objects.Where(o => o.CompanyId == companyId);
        }

        public bool ObjectExists(Guid id)
        {
            return _context.Objects.Any(o => o.Id == id);
        }

        public void UpdateObject(Object obj)
        {
            _context.Objects.Attach(obj);
            _context.Entry(obj).Property(o => o.Name).IsModified = true;
            _context.SaveChanges();
        }
    }
}
