using Microsoft.EntityFrameworkCore;
using ServiceBook.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceBook.API.Repositories
{
    public class CompanyRepository : IRepository<Company>, ICompanyRepository
    {
        private ServiceBookContext _context;

        public CompanyRepository(ServiceBookContext context)
        {
            _context = context;
        }
        public IEnumerable<Company> GetAll()
        {
            return _context.Companies;
        }

        public Company GetById(Guid comapnyId)
        {
            return _context.Companies.FirstOrDefault(c => c.Id == comapnyId);
        }

        public Company GetFirstCompany()
        {
            return _context.Companies
                .Include(c => c.Customer).ThenInclude(u => u.Type)
                .Include(c => c.Providers).ThenInclude(d => d.Departments)
                .FirstOrDefault();
        }

        public IEnumerable<Provider> GetCompanyProviders(Guid companyId)
        {
            return _context.Companies.FirstOrDefault(c => c.Id == companyId).Providers;
        }

        public string GetCompanyName(Guid id)
        {
            return _context.Companies.Where(c => c.Id == id).Select(c => c.Name).First();
        }

        public string GetCompanyImageName(Guid id)
        {
            return _context.Companies.Where(c => c.Id == id).Select(c => c.ImageName).First();
        }
    }
}
