using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceBook.API.Entities;
using ServiceBook.API.Models;
using ServiceBook.API.Repositories;
using System;
using System.Collections.Generic;

namespace ServiceBook.API.Controllers
{
    [Produces("application/json")]
    [Route("api/objects")]
    public class ObjectController : Controller
    {
        private IObjectRepository _objectRepository;

        public ObjectController(IObjectRepository objectRepository)
        {
            _objectRepository = objectRepository;
        }

       
        [HttpGet("{id}", Name = "GetObject")] 
        public IActionResult GetObject(Guid id)
        {
            Entities.Object objectFromRepo = _objectRepository.GetById(id);

            return Ok(objectFromRepo);
        }

        [HttpGet("company/{companyId}", Name = "GetObjectsForCompany")]
        public IActionResult GetObjectsForCompany(Guid companyId)
        {
            IEnumerable<Entities.Object> objectsFromRepo = _objectRepository.GetObjectsForCompany(companyId);
            IEnumerable<ObjectForDropdownDto> objects = Mapper.Map<IEnumerable<Entities.Object>, IEnumerable<ObjectForDropdownDto>>(objectsFromRepo);

            return Ok(objects);
        }

        [HttpGet("{objectId}/departments", Name = "GetDeparmentsForObject")]
        public IActionResult GetDeparmentsForObject(Guid objectId)
        {
            IEnumerable<Department> departmentsFromRepo = _objectRepository.GetDepartmentsForObject(objectId);

            return Ok(departmentsFromRepo);
        }

    }
}
