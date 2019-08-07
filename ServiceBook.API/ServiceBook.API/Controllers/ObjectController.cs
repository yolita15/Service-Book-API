using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ServiceBook.API.Entities;
using ServiceBook.API.Models;
using ServiceBook.API.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using Object = ServiceBook.API.Entities.Object;

namespace ServiceBook.API.Controllers
{
    [Produces("application/json")]
    [Route("api/objects")]
    public class ObjectController : Controller
    {
        private IObjectRepository _objectRepository;
        private readonly IHostingEnvironment _env;

        public ObjectController(IObjectRepository objectRepository, IHostingEnvironment env)
        {
            _objectRepository = objectRepository;
            _env = env;
        }


        [HttpGet("{id}", Name = "GetObject")]
        public IActionResult GetObject(Guid id)
        {
            Object objectFromRepo = _objectRepository.GetById(id);
            ObjectDto obj = Mapper.Map<ObjectDto>(objectFromRepo);

            return Ok(obj);
        }

        [HttpGet("company/{companyId}", Name = "GetObjectsForCompany")]
        public IActionResult GetObjectsForCompany(Guid companyId)
        {
            IEnumerable<Object> objectsFromRepo = _objectRepository.GetObjectsForCompany(companyId);
            IEnumerable<ObjectForDropdownDto> objects = Mapper.Map<IEnumerable<Object>, IEnumerable<ObjectForDropdownDto>>(objectsFromRepo);

            return Ok(objects);
        }

        [HttpGet("{objectId}/departments", Name = "GetDeparmentsForObject")]
        public IActionResult GetDeparmentsForObject(Guid objectId)
        {
            IEnumerable<Department> departmentsFromRepo = _objectRepository.GetDepartmentsForObject(objectId);

            return Ok(departmentsFromRepo);
        }

        [HttpGet("{objectId}/users", Name = "GetUsersForObject")]
        public IActionResult GetUsersForObject(Guid objectId)
        {
            IEnumerable<User> usersFromRepo = _objectRepository.GetUsersForObject(objectId);
            IEnumerable<UserDto> users = Mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(usersFromRepo);

            return Ok(users);
        }

        [HttpPut("{objectId}", Name = "UpdateObject")]
        public IActionResult UpdateObject(Guid objectId, [FromBody] Object obj)
        {
            if (_objectRepository.ObjectExists(objectId) == false)
            {
                return NotFound();
            }

            _objectRepository.UpdateObject(obj);
            return Ok();
        }

        [HttpGet("{objectId}/image")]
        public IActionResult GetImage(Guid objectId)
        {
            string imageName = _objectRepository.GetImageUrl(objectId);
            string objectName = _objectRepository.GetObjectName(objectId);

            string path = _env.WebRootFileProvider.GetFileInfo($"Images/Objects/{objectName}/{imageName}")?.PhysicalPath;

            if (System.IO.File.Exists(path))
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
