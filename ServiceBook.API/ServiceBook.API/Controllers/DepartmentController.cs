using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ServiceBook.API.Entities;
using ServiceBook.API.Repositories;
using System;
using System.IO;

namespace ServiceBook.API.Controllers
{
    [Produces("application/json")]
    [Route("api/departments")]
    public class DepartmentController : Controller
    {
        private IDepartmentRepository _departmentRepository;
        private readonly IHostingEnvironment _env;

        public DepartmentController(IDepartmentRepository departmentRepository, IHostingEnvironment env)
        {
            _departmentRepository = departmentRepository;
            _env = env;
        }

        [HttpGet("{departmentId}/image", Name = "GetDeparmentImage")]
        public IActionResult GetDeparmentImage(Guid departmentId)
        {
            string imageName = _departmentRepository.GetDepartmentImageName(departmentId);

            string path = _env.WebRootFileProvider.GetFileInfo($"Images/Departments/{imageName}")?.PhysicalPath;
            if (System.IO.File.Exists(path))
            {
                FileStream image = System.IO.File.OpenRead(path);
                return File(image, "image/png");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
