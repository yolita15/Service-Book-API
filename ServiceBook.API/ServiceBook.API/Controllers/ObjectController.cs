using Microsoft.AspNetCore.Mvc;
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

        [HttpGet(Name = "GetObjects")]
        public IActionResult GetObjects()
        {
            IEnumerable<Entities.Object> objectsFromRepo = _objectRepository.GetAll();

            return Ok(objectsFromRepo);
        }

        [HttpGet("{id}", Name = "GetObject")] 
        public IActionResult GetObject(Guid id)
        {
            Entities.Object objectFromRepo = _objectRepository.GetById(id);

            return Ok(objectFromRepo);
        }
    }
}
