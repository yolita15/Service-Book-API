using Microsoft.AspNetCore.Mvc;
using ServiceBook.API.Entities;
using ServiceBook.API.Repositories;
using System.Collections.Generic;

namespace ServiceBook.API.Controllers
{
    [Produces("application/json")]
    [Route("api/object-types")]
    public class ObjectTypeController : Controller
    {
        private IObjectTypeRepository _objectTypeRepository;

        public ObjectTypeController(IObjectTypeRepository objectTypeRepository)
        {
            _objectTypeRepository = objectTypeRepository;
        }

        [HttpGet(Name = "GetObjectTypes")]
        public IActionResult GetObjectTypes()
        {
            IEnumerable<ObjectType> objectTypesFromRepo = _objectTypeRepository.GetAll();

            return Ok(objectTypesFromRepo);
        }
    }
}
