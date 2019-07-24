using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceBook.API.Entities;
using ServiceBook.API.Models;
using ServiceBook.API.Repositories;
using System;

namespace ServiceBook.API.Controllers
{
    [Produces("application/json")]
    [Route("api/company")]
    public class CompanyController : Controller
    {
        private ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpGet]
        public IActionResult GetCompany()
        {
            Company companyFromRepo = _companyRepository.GetFirstCompany();
            CompanyDto company = Mapper.Map<CompanyDto>(companyFromRepo);

            return Ok(company);
        }
    }
}
