using Microsoft.AspNetCore.Mvc;
using ServiceBook.API.Repositories;

namespace ServiceBook.API.Controllers
{
    public class CompanyController : Controller
    {
        private ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
    }
}
