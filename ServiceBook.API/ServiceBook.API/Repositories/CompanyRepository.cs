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
        public void Create(Company entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Company entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Company> GetAll()
        {
            return _context.Companies;
        }

        public Company GetById(Guid comapnyId)
        {
            return _context.Companies.FirstOrDefault(c => c.Id == comapnyId);
        }

        public void Update(Company entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Provider> GetCompanyProviders(Guid companyId)
        {
            return _context.Companies.FirstOrDefault(c => c.Id == companyId).Providers;
        }
    }
}
