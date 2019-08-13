using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceBook.API.Entities;
using ServiceBook.API.Models;
using ServiceBook.API.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            IEnumerable<User> usersFromRepo = objectFromRepo.ObjectUsers.Select(od => od.User);
            IEnumerable<UserDto> users = Mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(usersFromRepo);

            ObjectDto obj = Mapper.Map<ObjectDto>(objectFromRepo);
            obj.Departments = objectFromRepo.ObjectDepartments.Select(od => od.Department);
            obj.Users = users;
            obj.Path = GetPathToObject(id);

            return Ok(obj);
        }

        [HttpGet("company/{companyId}", Name = "GetObjectsForCompany")]
        public IActionResult GetObjectsForCompany(Guid companyId)
        {
            IEnumerable<Object> objectsFromRepo = _objectRepository.GetObjectsForCompany(companyId);
            IEnumerable<ObjectForDropdownDto> objects = Mapper.Map<IEnumerable<Object>, IEnumerable<ObjectForDropdownDto>>(objectsFromRepo);

            return Ok(objects);
        }

        [HttpPut("{objectId}", Name = "UpdateObject")]
        public IActionResult UpdateObject(Guid objectId, [FromQuery(Name = "apply")]int applyForChildren, [FromBody] ObjectDto obj)
        {
            if (_objectRepository.ObjectExists(objectId) == false)
            {
                return NotFound();
            }

            List<Department> departmentsToBeUpdated = obj.Departments.ToList();
            Object objectFromBody = Mapper.Map<Object>(obj);
            _objectRepository.UpdateObject(objectFromBody, departmentsToBeUpdated, applyForChildren);

            if(applyForChildren == 1)
            {
                ApplyDepartmentChangesForChildren(objectId, departmentsToBeUpdated);
            }

            return Ok();
        }

        [HttpPut("{objectId}/{imageName}", Name = "UploadImage")]
        public IActionResult UploadImage(Guid objectId, string imageName, IFormFile image)
        {
            string objectName = _objectRepository.GetObjectName(objectId);
            string path = _env.WebRootFileProvider.GetFileInfo($"Images/Objects/{objectName}")?.PhysicalPath;

            if(Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }

            path += $"/{imageName}";
            image.CopyTo(new FileStream(path, FileMode.Create));

            return Ok();
        }


        [HttpGet("{objectId}/image", Name = "GetImage")]
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

        private string GetPathToObject(Guid objectId)
        {
            Object obj = _objectRepository.GetById(objectId);
            if(obj.ParentId != null)
            {
                return $"{GetPathToObject(obj.ParentId.GetValueOrDefault())}/{_objectRepository.GetObjectName(objectId)}";
            }
            else
            {
                return _objectRepository.GetObjectName(objectId);
            }
        }

        private void ApplyDepartmentChangesForChildren(Guid id, List<Department> departments)
        {
            IEnumerable<Object> children = _objectRepository.GetObjectsWithParentId(id);

            if(children != null)
            {
                foreach (Object child in children)
                {
                    _objectRepository.UpdateDepartmentsForObject(child.Id, departments);
                    ApplyDepartmentChangesForChildren(child.Id, departments);
                }
            }
        }
    }
}
