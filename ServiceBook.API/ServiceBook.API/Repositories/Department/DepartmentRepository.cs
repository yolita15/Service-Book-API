using ServiceBook.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceBook.API.Repositories
{

    public class DepartmentRepository : IDepartmentRepository
    {
        private ServiceBookContext _context;

        public DepartmentRepository(ServiceBookContext context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetAll()
        {
            throw new NotImplementedException();
        }

        public Department GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public string GetDepartmentImageName(Guid departmentId)
        {
            return _context.Departments.Where(d => d.Id == departmentId).Select(d => d.ImageName).First();
        }
    }
}
