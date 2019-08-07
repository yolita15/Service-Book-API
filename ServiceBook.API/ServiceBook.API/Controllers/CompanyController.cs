using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ServiceBook.API.Entities;
using ServiceBook.API.Models;
using ServiceBook.API.Repositories;
using System;
using System.IO;

namespace ServiceBook.API.Controllers
{
    [Produces("application/json")]
    [Route("api/company")]
    public class CompanyController : Controller
    {
        private ICompanyRepository _companyRepository;
        private readonly IHostingEnvironment _env;

        public CompanyController(ICompanyRepository companyRepository, IHostingEnvironment env)
        {
            _companyRepository = companyRepository;
            _env = env;
        }

        [HttpGet(Name = "GetCompany")]
        public IActionResult GetCompany()
        {
            Company companyFromRepo = _companyRepository.GetFirstCompany();
            CompanyDto company = Mapper.Map<CompanyDto>(companyFromRepo);

            return Ok(company);
        }

        [HttpGet("{companyId}/image")]
        public IActionResult GetImage(Guid companyId)
        {
            string imageName = _companyRepository.GetCompanyImageName(companyId);
            string companyName = _companyRepository.GetCompanyName(companyId);

            string path = _env.WebRootFileProvider.GetFileInfo($"Images/Companies/{companyName}/{imageName}")?.PhysicalPath;
            if(System.IO.File.Exists(path))
            {
                FileStream image = System.IO.File.OpenRead(path);
                return File(image, "image/jpeg");
            } 
            else
            {
                return NotFound();
            }
        }
    }
}
