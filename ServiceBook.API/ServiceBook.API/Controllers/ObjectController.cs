using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceBook.API.Entities;
using ServiceBook.API.Models;
using ServiceBook.API.Repositories;
using System;
using System.Collections.Generic;
using Object = ServiceBook.API.Entities.Object;

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

        [HttpPut("{objectId}", Name = "UpdateObject")]
        public IActionResult UpdateObject(Guid objectId, [FromBody] Object obj)
        {
            if(_objectRepository.ObjectExists(objectId) == false)
            {
                return NotFound();
            }

            _objectRepository.UpdateObject(obj);
            return Ok();
        }

    }
}
