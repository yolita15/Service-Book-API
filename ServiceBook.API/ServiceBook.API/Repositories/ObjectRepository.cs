using Microsoft.EntityFrameworkCore;
using ServiceBook.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceBook.API.Repositories
{
    public class ObjectRepository : IRepository<Entities.Object>, IObjectRepository
    {
        private ServiceBookContext _context;

        public ObjectRepository(ServiceBookContext context)
        {
            _context = context;
        }
        public void Create(Entities.Object entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Entities.Object entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entities.Object> GetAll()
        {
            return _context.Objects;
        }

        public Entities.Object GetById(Guid objectId)
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

        public IEnumerable<Entities.Object> GetObjectsForCompany(Guid companyId)
        {
            return _context.Objects.Where(o => o.CompanyId == companyId);
        }

        public void Update(Entities.Object entity)
        {
            throw new NotImplementedException();
        }
    }
}
