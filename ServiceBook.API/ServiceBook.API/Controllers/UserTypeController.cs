using Microsoft.AspNetCore.Mvc;
using ServiceBook.API.Entities;
using ServiceBook.API.Repositories;
using System.Collections.Generic;

namespace ServiceBook.API.Controllers
{
    [Produces("application/json")]
    [Route("api/user-types")]
    public class UserTypeController : Controller
    {
        private IUserTypeRepository _userTypeRepository;

        public UserTypeController(IUserTypeRepository userTypeRepository)
        {
            _userTypeRepository = userTypeRepository;
        }

        [HttpGet(Name = "GetAllUserTypes")]
        public IActionResult GetAllUserTypes()
        {
            IEnumerable<UserType> userTypesFromRepo = _userTypeRepository.GetAll();

            return Ok(userTypesFromRepo);
        }
    }
}
