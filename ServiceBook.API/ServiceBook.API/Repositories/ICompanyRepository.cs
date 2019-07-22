using ServiceBook.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceBook.API.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        IEnumerable<Provider> GetCompanyProviders(Guid companyId);
    }
}
