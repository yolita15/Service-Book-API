using ServiceBook.API.Entities;
using System;
using System.Collections.Generic;

namespace ServiceBook.API.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Company GetFirstCompany();
  
        IEnumerable<Provider> GetCompanyProviders(Guid companyId);

        string GetCompanyName(Guid id);

        string GetCompanyImageName(Guid id);
    }
}
